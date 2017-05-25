using System;
using Randomizer;

namespace ConsoleClient
{
    public class Program
    {
        private static readonly TaskContainerSettings Settings = new TaskContainerSettings
        {
            Randomize = true
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Task randomizer");
            Console.WriteLine("Reading tasks from {0}", Properties.Settings.Default.TaskFolder);

            var reader = new FileReader(Properties.Settings.Default.TaskFolder);
            var fileInput = reader.ReadFiles();
            var tasks = TaskCollectionsCreator.CreateTasks(Settings, fileInput);

            var task = tasks.NextTask();
            while (task.HasValue)
            {
                Console.WriteLine(task.Value.Content);
                Console.ReadLine();
                task = tasks.NextTask();
            }

            Console.WriteLine("Task finished.");
            Console.ReadLine();
        }
    }
}

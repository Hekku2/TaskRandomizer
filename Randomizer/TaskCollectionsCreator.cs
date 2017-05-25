using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
    public class TaskCollectionsCreator
    {
        public static TaskCollections CreateTasks(TaskContainerSettings settings, List<List<string>> stringContainers)
        {
            var taskCollection = new TaskCollections();
            foreach (var lines in stringContainers)
            {
                var tasks = lines
                    .Where(ShouldBeIncluded)
                    .Select(TaskCreator.CreateTask).ToList();
                var stack = new TaskContainer(settings, tasks);
                taskCollection.AddTasks(stack);
            }

            return taskCollection;
        }

        private static bool ShouldBeIncluded(string line)
        {
            return !string.IsNullOrEmpty(line) && !line.StartsWith("#");
        }
    }
}

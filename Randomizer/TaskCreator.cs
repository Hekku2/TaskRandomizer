namespace Randomizer
{
    public static class TaskCreator
    {
        public static Task CreateTask(string taskString)
        {
            return new Task
            {
                Content = taskString
            };
        }
    }
}

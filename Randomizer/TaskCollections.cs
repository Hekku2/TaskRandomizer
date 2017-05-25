using System.Collections.Generic;
using Functional.Maybe;

namespace Randomizer
{
    public class TaskCollections
    {
        private readonly Queue<TaskContainer> _taskStacks;

        public TaskCollections()
        {
            _taskStacks = new Queue<TaskContainer>();
        }

        public void AddTasks(TaskContainer container)
        {
            _taskStacks.Enqueue(container);
        }

        public Maybe<Task> NextTask()
        {
            while (_taskStacks.Count > 0)
            {
                var stack = _taskStacks.Peek();
                if (stack.HasTask())
                    return stack.NextTask();
                _taskStacks.Dequeue();
            }
            return Maybe<Task>.Nothing;
        }
    }
}

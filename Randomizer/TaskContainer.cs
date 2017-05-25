using System;
using System.Collections.Generic;
using Functional.Maybe;

namespace Randomizer
{
    public class TaskContainer
    {
        private readonly Queue<Task> _tasks;

        public TaskContainer(TaskContainerSettings settings, IList<Task> tasks)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }

            _tasks = new Queue<Task>();

            if (settings.Randomize)
            {
                tasks = ListRandomizer.Suffle(tasks);
            }
                

            foreach (var task in tasks)
            {
                _tasks.Enqueue(task);
            }
        }

        public bool HasTask()
        {
            return _tasks.Count > 0;
        }

        public Maybe<Task> NextTask()
        {
            return HasTask() ? 
                _tasks.Dequeue().ToMaybe() : Maybe<Task>.Nothing;
        }
    }
}

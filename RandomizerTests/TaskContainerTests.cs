using NUnit.Framework;
using Randomizer;
using Task = Randomizer.Task;

namespace RandomizerTests
{
    [TestFixture]
    public class TaskContainerTests
    {
        private TaskContainerSettings _defaultTestSettings;

        [SetUp]
        public void Setup()
        {
            _defaultTestSettings = new TaskContainerSettings
            {
                Randomize = false
            };
        }

        [Test]
        public void TestHasTaskReturnsFalseWhenStackIsEmpty()
        {
            var stack = new TaskContainer(_defaultTestSettings, new Task[0]);
            Assert.False(stack.HasTask());
        }

        [Test]
        public void TestHasTaskReturnsTrueWhenThereIsATask()
        {
            var stack = new TaskContainer(_defaultTestSettings, new[]
            {
                new Task()
            });
            Assert.True(stack.HasTask());
        }

        [Test]
        public void TestNextTaskReturnsNothingIfStackIsEmpty()
        {
            var stack = new TaskContainer(_defaultTestSettings, new Task[0]);
            Assert.False(stack.NextTask().HasValue);
        }

        [Test]
        public void TestNextTaskReturnsNextTask()
        {
            var expected = new Task
            {
                Content = "task"
            };
            var stack = new TaskContainer(_defaultTestSettings, new[] { expected });
            var task = stack.NextTask();
            Assert.True(task.HasValue);
            Assert.AreEqual(expected, task.Value);
            Assert.False(stack.NextTask().HasValue);
        }
    }
}

using NUnit.Framework;
using Randomizer;

namespace RandomizerTests
{
    [TestFixture]
    public class TaskCollectionsTests
    {
        private TaskContainerSettings _defaultTestSettings;

        private TaskCollections _taskCollections;

        [SetUp]
        public void Setup()
        {
            _taskCollections = new TaskCollections();
            _defaultTestSettings = new TaskContainerSettings
            {
                Randomize = false
            };
        }

        [Test]
        public void TestNextTaskReturnNothingIfThereAreNoTasks()
        {
            Assert.False(_taskCollections.NextTask().HasValue);
        }

        [Test]
        public void TestNextTaskReturnsTaskFromNextStack()
        {
            var expected = new Task {Content = "Expected"};

            _taskCollections.AddTasks(new TaskContainer(_defaultTestSettings, new Task[0]));
            _taskCollections.AddTasks(new TaskContainer(_defaultTestSettings, new[]
            {
                expected
            }));

            var task = _taskCollections.NextTask();
            Assert.True(task.HasValue);
            Assert.AreEqual(expected, task.Value);

            Assert.False(_taskCollections.NextTask().HasValue);
        }
    }
}

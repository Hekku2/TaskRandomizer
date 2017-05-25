using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Randomizer;

namespace RandomizerTests
{
    [TestFixture]
    public class TaskCollectionsCreatorTests
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
        public void TestCreateTasksCreatesCorrectTaskCollection()
        {
            var input = new List<List<string>>
            {
                new List<string>{"1A", "1B"},
                new List<string>{"2A", "2B", "2C"},
                new List<string>{"3A", "3B"}
            };
            var result = TaskCollectionsCreator.CreateTasks(_defaultTestSettings, input);
            var flat = input.SelectMany(r => r);
            foreach (var expected in flat)
            {
                var actual = result.NextTask();
                Assert.IsTrue(actual.HasValue);
                Assert.AreEqual(expected, actual.Value.Content);
            }

        }
    }
}

using NUnit.Framework;
using Randomizer;

namespace RandomizerTests
{
    [TestFixture]
    public class ListRandomizerTests
    {
        [Test]
        public void TestRandomizeResultContainsAllElements()
        {
            var input = new[]
            {
                "a", "b", "c", "d"
            };
            var result = ListRandomizer.Suffle(input);
            foreach (var word in input)
            {
                Assert.IsTrue(result.Contains(word), $"Result set did not contain word {word}");
            }
        }
    }
}

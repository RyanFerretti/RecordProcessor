using NUnit.Framework;
using RecordProcessor.Console;

namespace RecordProcessor.AcceptanceTests.Console
{
    [TestFixture]
    public class TestContainer
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public static void ShouldExerciseContainer()
        {
            var result = Program.Main(new string[]{});
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
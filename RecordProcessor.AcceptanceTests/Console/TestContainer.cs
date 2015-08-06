using NUnit.Framework;
using RecordProcessor.Console;

namespace RecordProcessor.AcceptanceTests.Console
{
    [TestFixture]
    public class TestContainer
    {
        [Test]
        public static void ShouldInitializeContainer()
        {
            var result = Program.Main(new string[]{});
            Assert.That(result, Is.EqualTo(Program.Error));
        }
    }
}
using NUnit.Framework;
using RecordProcessor.Application;

namespace RecordProcessor.UnitTests.Application
{
    [TestFixture]
    public class TestRecordProcessorFromFile
    {
        private IRecordProcessor _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RecordProcessorFromFile();
        }

        [Test]
        public void ShouldDoSomething()
        {
            Assert.IsTrue(true);      
        }
    }
}
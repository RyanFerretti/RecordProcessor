using NUnit.Framework;
using RecordProcessor.Application.Parsers;

namespace RecordProcessor.UnitTests.Application.Parsers
{
    [TestFixture]
    public class TestRecordParser
    {
        private IParser _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RecordParser();
        }

        [Test]
        public void ShouldReturn()
        {
            Assert.That(_sut.Parse(""),Is.Not.Null);
        }
    }
}
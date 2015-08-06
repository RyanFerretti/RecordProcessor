using NUnit.Framework;
using RecordProcessor.Application;
using Rhino.Mocks;

namespace RecordProcessor.UnitTests.Application
{
    [TestFixture]
    public class TestRecordProcessorFromFile
    {
        private IRecordProcessor _sut;
        private IPrinter _printer;

        [SetUp]
        public void Setup()
        {
            _printer = MockRepository.GenerateMock<IPrinter>();
            _sut = new RecordProcessorFromFile(_printer);
        }

        [Test]
        public void ShouldReturnFailure()
        {
            var result = _sut.Run(new string[]{});
            Assert.That(result.Success,Is.False);
        }

        [Test]
        public void ShouldPrintMessage()
        {
            _sut.Run(new string[] {});
            _printer.AssertWasCalled(p => p.Print("not implemented"));    
        }
    }
}
using Autofac;
using NUnit.Framework;
using RecordProcessor.Application;
using RecordProcessor.Console.IoC;
using Rhino.Mocks;

namespace RecordProcessor.AcceptanceTests.Application
{
    [TestFixture]
    public class TestApplication
    {
        private IPrinter _mockPrinter;
        private IRecordProcessor _sut;

        [SetUp]
        public void Setup()
        {
            var container = BuildContainer();
            _sut = container.Resolve<IRecordProcessor>();
        }

        [Test]
        public void ShouldReturnResultWhenRun()
        {
            var result = _sut.Run(new string[] { });
            Assert.That(result.Success,Is.False);
        }

        [Test]
        public void ShouldPrintRecordsWhenRun()
        {
            _sut.Run(new string[] {});
            _mockPrinter.AssertWasCalled(p => p.Print("not implemented"));
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConsoleModule());
            OverrideAutoFacRegistrations(builder);
            return builder.Build();
        }

        private void OverrideAutoFacRegistrations(ContainerBuilder builder)
        {
            _mockPrinter = MockRepository.GenerateMock<IPrinter>();
            builder.Register(c => _mockPrinter).As<IPrinter>();
        }
    }
}
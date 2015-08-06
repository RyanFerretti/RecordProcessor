using NUnit.Framework;
using RecordProcessor.Application;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Validators;
using Rhino.Mocks;

namespace RecordProcessor.UnitTests.Application
{
    [TestFixture]
    public class TestRecordProcessorFromFile
    {
        private IRecordProcessor _sut;
        private IPrinter _printer;
        private IValidator<string[]> _validator;
        private IBuilder<Record> _builder;

        [SetUp]
        public void Setup()
        {
            _builder = MockRepository.GenerateMock<IBuilder<Record>>();
            _printer = MockRepository.GenerateMock<IPrinter>();
            _validator = MockRepository.GenerateMock<IValidator<string[]>>();
            _sut = new RecordProcessorFromFile(_builder,_validator,_printer);
        }

        [Test]
        public void ShouldReturnFailureIfValidationFails()
        {
            var args = new string[]{};
            var validationResult = new ValidationResult{IsValid = false, ErrorMessage = "error"};
            
            _validator.Stub(v => v.IsValid(args)).Return(validationResult);

            var result = _sut.Run(args);

            Assert.That(result.Success,Is.False);
            _printer.AssertWasCalled(p => p.Print(validationResult.ErrorMessage));   
        }

        [Test]
        public void ShouldBuildRecords()
        {
            var args = new string[] { };
            var validationResult = new ValidationResult { IsValid = true};

            _validator.Stub(v => v.IsValid(args)).Return(validationResult);

            var result = _sut.Run(args);

            _builder.AssertWasCalled(b => b.Build(args));
        }
    }
}
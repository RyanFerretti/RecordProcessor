using System;
using System.Collections.Generic;
using NUnit.Framework;
using RecordProcessor.Application;
using RecordProcessor.Application.Validators;
using Rhino.Mocks;

namespace RecordProcessor.UnitTests.Application.Validators
{
    [TestFixture]
    public class TestArgumentsValidator
    {
        private ArgumentsValidator _sut;
        private IContentFinder _fileFinder;

        private const string ArgsRequiredErrorMessage = "args are required";

        [SetUp]
        public void Setup()
        {
            _fileFinder = MockRepository.GenerateMock<IContentFinder>();
            _sut = new ArgumentsValidator(_fileFinder);    
        }

        [Test]
        public void ShouldReturnErrorIfArgsAreNull()
        {
            var result = _sut.IsValid(null);
            Assert.That(result.IsValid,Is.False);
            Assert.That(result.ErrorMessage,Is.EqualTo(ArgsRequiredErrorMessage));
        }

        [Test]
        public void ShouldReturnErrorIfArgsAreEmpty()
        {
            var result = _sut.IsValid(new string[]{});
            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.EqualTo(ArgsRequiredErrorMessage));
        }

        [Test]
        public void ShouldCheckThatArgsAreValidFiles()
        {
            var temp1Txt = "temp1.txt";
            var temp2Txt = "temp2.txt";

            _fileFinder.Stub(f => f.Exists(Arg<string>.Is.Anything)).Return(true);

            var result = _sut.IsValid(new[] {temp1Txt, temp2Txt});

            Assert.That(result.IsValid, Is.True);
            Assert.That(result.ErrorMessage, Is.Empty);
        }

        [Test]
        public void ShouldReturnErrorIfFilesAreNotFound()
        {
            var temp1Txt = "temp1.txt";
            var temp2Txt = "temp2.txt";

            _fileFinder.Stub(f => f.Exists(temp1Txt)).Return(true);
            _fileFinder.Stub(f => f.Exists(temp2Txt)).Return(false);

            var result = _sut.IsValid(new[] { temp1Txt, temp2Txt });

            Assert.That(result.IsValid, Is.False);
            Assert.That(result.ErrorMessage, Is.StringContaining(temp2Txt));
        }
    }
}
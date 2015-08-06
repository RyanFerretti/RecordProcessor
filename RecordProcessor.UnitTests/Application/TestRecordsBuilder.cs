using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RecordProcessor.Application;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Parsers;
using Rhino.Mocks;

namespace RecordProcessor.UnitTests.Application
{
    [TestFixture]
    public class TestRecordsBuilder
    {
        private IContentHelper _contentHelper;
        private IParser _parser;
        private RecordsBuilder _sut;

        [SetUp]
        public void Setup()
        {
            _parser = MockRepository.GenerateMock<IParser>();
            _contentHelper = MockRepository.GenerateMock<IContentHelper>();
            _sut = new RecordsBuilder(_contentHelper,_parser);
        }

        [Test]
        public void ShouldReadFileAndParse()
        {
            var path1 = "path1";
            var line1 = "line1";
            var expectedRecord = new Record();
            var paths = new[] {path1};
            var linesOfContent = new List<string>{line1};

            _contentHelper.Stub(h => h.ReadLines(path1)).Return(linesOfContent);
            _parser.Stub(p => p.Parse(line1)).Return(expectedRecord);

            var result = _sut.Build(paths);

            Assert.That(result.Count(),Is.EqualTo(linesOfContent.Count));
            Assert.That(result.First(),Is.SameAs(expectedRecord));
        }

        [Test]
        public void ShouldReadMultipleFilesAndParse()
        {
            var path1 = "path1";
            var path2 = "path2";
            var line1 = "line1";
            var line2 = "line2";
            var expectedRecord1 = new Record{FirstName = "Ryan"};
            var expectedRecord2 = new Record{FirstName = "Charlie"};
            var linesOfContent1 = new List<string> { line1 };
            var linesOfContent2 = new List<string> { line2 };
            var paths = new[] { path1, path2 };

            _contentHelper.Stub(h => h.ReadLines(path1)).Return(linesOfContent1);
            _contentHelper.Stub(h => h.ReadLines(path2)).Return(linesOfContent2);
            _parser.Stub(p => p.Parse(line1)).Return(expectedRecord1);
            _parser.Stub(p => p.Parse(line2)).Return(expectedRecord2);

            var result = _sut.Build(paths);
            
            Assert.That(result.Count(), Is.EqualTo(linesOfContent1.Count + linesOfContent2.Count));
            Assert.That(result.First(), Is.SameAs(expectedRecord1));
            Assert.That(result.Last(), Is.SameAs(expectedRecord2));
        }
    }
}
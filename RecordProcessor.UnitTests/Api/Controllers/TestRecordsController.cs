using System.Collections.Generic;
using System.Web.Http.Results;
using NUnit.Framework;
using RecordProcessor.Api.Controllers;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Sorters;
using Rhino.Mocks;

namespace RecordProcessor.UnitTests.Api.Controllers
{
    [TestFixture]
    public class TestRecordsController
    {
        private RecordsController _sut;
        private ISortStrategyFactory _sortFactory;
        private IList<Record> _records;

        [SetUp]
        public void Setup()
        {
            _records = new List<Record>();
            _sortFactory = MockRepository.GenerateMock<ISortStrategyFactory>();
            _sut = new RecordsController(_sortFactory,_records);
        }

        [Test]
        public void ShouldGetAllRecords()
        {
            var result = _sut.Get() as OkNegotiatedContentResult<IEnumerable<Record>>;
            Assert.That(result,Is.Not.Null);
            Assert.That(result.Content,Is.SameAs(_records));
        }

        [Test]
        public void ShouldGetSortedRecords()
        {
            const string sortingName = "sort";
            var sortedRecords = new List<Record>();
            var mockStrategy = MockRepository.GenerateMock<ISortStrategy>();
            _sortFactory.Stub(f => f.Get(sortingName)).Return(mockStrategy);
            mockStrategy.Stub(f => f.Execute(_records)).Return(sortedRecords);
            
            var result = _sut.Get(sortingName) as OkNegotiatedContentResult<IEnumerable<Record>>;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.SameAs(sortedRecords));
        }
    }
}
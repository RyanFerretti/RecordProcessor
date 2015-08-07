using NUnit.Framework;
using RecordProcessor.Application.Sorters;

namespace RecordProcessor.UnitTests.Application.Sorters
{
    [TestFixture]
    public class TestSortStratedyFactory
    {
        private ISortStrategyFactory _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SortStrategyFactory();
        }

        [Test]
        public void ShouldReturnFemalesFirstSort()
        {
            var result = _sut.Get(SortMethod.FemalesFirst);
            Assert.That(result,Is.TypeOf<FemalesFirstSortStrategy>());
        }

        [Test]
        public void ShouldReturnBirthDateSort()
        {
            var result = _sut.Get(SortMethod.Birthdate);
            Assert.That(result, Is.TypeOf<BirthDateSortStrategy>());
        }

        [Test]
        public void ShouldReturnLastNameSort()
        {
            var result = _sut.Get(SortMethod.LastName);
            Assert.That(result, Is.TypeOf<LastNameSortStrategy>());
        }
    }
}
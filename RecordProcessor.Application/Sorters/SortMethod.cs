using System;

namespace RecordProcessor.Application.Sorters
{
    public enum SortMethod
    {
        FemalesFirst = 1,
        Birthdate = 2,
        LastName = 3
    }

    public class SortStrategyFactory : ISortStrategyFactory
    {
        public ISortStrategy Get(SortMethod sortMethod)
        {
            switch (sortMethod)
            {
                case SortMethod.FemalesFirst:
                    return new FemalesFirstSortStrategy();
                case SortMethod.Birthdate:
                    return new BirthDateSortStrategy();
                case SortMethod.LastName:
                    return new LastNameSortStrategy();
                default:
                    return new FemalesFirstSortStrategy();
            }
        }
    }
}

namespace RecordProcessor.Application.Sorters
{
    public interface ISortStrategyFactory
    {
        ISortStrategy Get(SortMethod sortMethod);
    }
}
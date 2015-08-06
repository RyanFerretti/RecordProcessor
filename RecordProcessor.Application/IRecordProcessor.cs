namespace RecordProcessor.Application
{
    public interface IRecordProcessor
    {
        FileProcessedResult Run(string[] args);
    }
}

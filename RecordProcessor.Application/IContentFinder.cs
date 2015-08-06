namespace RecordProcessor.Application
{
    public interface IContentFinder
    {
        bool Exists(string path);
    }
}

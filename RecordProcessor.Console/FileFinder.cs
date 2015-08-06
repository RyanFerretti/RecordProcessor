using System.IO;
using RecordProcessor.Application;

namespace RecordProcessor.Console
{
    public class FileFinder : IContentFinder
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}

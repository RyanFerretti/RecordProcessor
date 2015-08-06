using System.Collections.Generic;
using System.IO;
using RecordProcessor.Application;

namespace RecordProcessor.Console
{
    public class FileHelper : IContentHelper
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }
    }
}

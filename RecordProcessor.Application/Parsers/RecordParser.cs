using System.IO;
using RecordProcessor.Application.Domain;

namespace RecordProcessor.Application.Parsers
{
    public class RecordParser : IParser
    {
        public Record Parse(string recordData)
        {
            return new Record();
        }
    }
}

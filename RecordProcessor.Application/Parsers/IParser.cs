using RecordProcessor.Application.Domain;

namespace RecordProcessor.Application.Parsers
{
    public interface IParser
    {
        Record Parse(string data);
    }
}
using System.Collections.Generic;
using System.Linq;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Parsers;

namespace RecordProcessor.Application
{
    public class RecordsBuilder : IBuilder<Record>
    {
        private readonly IContentHelper _contentHelper;
        private readonly IParser _parser;

        public RecordsBuilder(IContentHelper contentHelper, IParser parser)
        {
            _contentHelper = contentHelper;
            _parser = parser;
        }

        public IEnumerable<Record> Build(string[] paths)
        {
            var result = new List<Record>();
            foreach (var content in paths.Select(path => _contentHelper.ReadLines(path)))
            {
                result.AddRange(content.Select(line => _parser.Parse(line)));
            }
            return result;
        }
    }
}

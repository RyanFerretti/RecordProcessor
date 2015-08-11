using System.Collections.Generic;
using System.Web.Http;
using RecordProcessor.Application.Domain;
using RecordProcessor.Application.Sorters;

namespace RecordProcessor.Api.Controllers
{
    public class RecordsController : ApiController
    {
        private readonly ISortStrategyFactory _sortStrategyFactory;
        private readonly IEnumerable<Record> _records;

        public RecordsController(ISortStrategyFactory sortStrategyFactory, IEnumerable<Record> records)
        {
            _sortStrategyFactory = sortStrategyFactory;
            _records = records;
        }

        // GET: records
        public IHttpActionResult Get()
        {
            return Ok(_records);
        }

        // GET: records/sort-strategy
        public IHttpActionResult Get(string id)
        {
            var sortedRecords = _sortStrategyFactory.Get(id).Execute(_records);
            return Ok(sortedRecords);
        }

        // POST: records
        public IHttpActionResult Post(Something data)
        {
            data.Message = "saved " + data.Message;
            return Ok(data);
        }
    }

    public class Something
    {
        public string Message { get; set; }

    }
}

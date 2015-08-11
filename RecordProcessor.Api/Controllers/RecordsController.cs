using System.Web.Http;

namespace RecordProcessor.Api.Controllers
{
    public class RecordsController : ApiController
    {
        // GET: records
        public IHttpActionResult Get()
        {
            var x = new Something{Message = "hello"};
            return Ok(x);
        }

        // GET: records/5
        public IHttpActionResult Get(string id)
        {
            var x = new Something { Message = id };
            return Ok(x);
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

using System.Collections.Generic;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: records
        public void Post([FromBody]string value)
        {

        }
    }

    class Something
    {
        public string Message { get; set; }

    }
}

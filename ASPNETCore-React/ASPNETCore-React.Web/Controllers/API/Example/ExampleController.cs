using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ASPNETCore_React.Web.Controllers.API.Example
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        // GET api/example
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/example/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/example
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/example/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/example/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

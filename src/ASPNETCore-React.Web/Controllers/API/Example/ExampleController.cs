using Microsoft.AspNetCore.Mvc;
using System;
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
            return new [] { "value1", "value2" };
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
            // As This example dont have a repository, 
            // we are not able to verify if the object was fully updated
        }

        // PUT api/example/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // As This example dont have a repository, 
            // we are not able to verify if the object was partially updated
        }

        // DELETE api/example/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // As This example dont have a repository, 
            // we are not able to verify if the object was deleted
        }
    }
}

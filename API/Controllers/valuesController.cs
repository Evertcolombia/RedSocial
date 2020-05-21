using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace DatingApp.API.Controllers
{
    // specifies the routes structures
    // creates a new route with this controller
    [Route("api/[controller]")]
    [ApiController]

    // Values controller will inheritance from controllerBase
    // is a base calsss for mvc controllers
    public class ValuesController : ControllerBase
    {

        // extract  the context from DataContext make it private
        private readonly DataContext _context;
        // instanciate the controller for DataContext using
        // the stracted context
        public ValuesController(DataContext context) {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            var values = await _context.Values.ToList();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
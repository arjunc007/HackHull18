using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        private readonly CurrencyContext _context;

        public CurrencyController(CurrencyContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Currency"};
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            CurrencyViewModel model = _context.CurrencyItems.
                Where(x => x.OwnerID == id).
                First();

            if (model == null)
                return NotFound();

            return new ObjectResult(model);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]CurrencyViewModel value)
        {
            var ci = _context.CurrencyItems.
                Where(x => value.OwnerID == x.OwnerID).First();

            if (ci == null)
                return NotFound();

            ci.CurrencyTotal = value.CurrencyTotal;
            ci.TransactionID = value.TransactionID;

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

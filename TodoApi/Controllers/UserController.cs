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
    public class UserController : Controller
    {
        private readonly LazyDbContext _context;

        public UserController(LazyDbContext context)
        {
            _context = context;
            if (_context.UserItems.Count() == 0)
            {
                _context.UserItems.Add(new UserViewModel
                {
                    Username = "Iskandar",
                    Password = "password",
                    ID = Guid.NewGuid().ToString()
                });
                _context.SaveChanges();
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Adw", "awda" };
        }

        // GET api/<controller>/username/password
        [HttpGet("{username}/{password}")]
        public ActionResult Get(string username, string password)
        {
            var model = _context.UserItems.
                Where(x => x.Username == username && x.Password == password).
                First();

            if (model == null)
                return NotFound();

            return new ObjectResult(model);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]UserViewModel value)
        {
            _context.UserItems.Add(value);
            _context.SaveChanges();

            return Ok();
            //return CreatedAtRoute(;
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

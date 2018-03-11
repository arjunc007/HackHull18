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

            string id = "";
            if (_context.UserItems.Count() == 0)
            {
                var users = new List<UserViewModel>
                {
                    new UserViewModel { ID = "1000", Password = "pass", Username = "Arjun"},
                    new UserViewModel { ID = "1001", Password = "password", Username = "Iskandar" },
                    new UserViewModel { ID = "1002", Password = "words", Username = "Josh" },
                    new UserViewModel { ID = "1003", Password = "", Username = "Ephra" }
                };
                id = users[0].ID;
                _context.AddRange(users);
            }

            if(_context.QuestItems.Count() == 0)
            {
                var quests = new List<QuestViewModel>
                {
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = id, Type = "Daily" , Text = "Attend all Lectures", Accepted = true, Progress = 1, EndPoint = 3, EndDate = DateTime.Today.AddDays(30), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = id, Type = "Quest", Text = "Complete Assignment 1", Accepted = true, Progress = 326, EndPoint = 1000, EndDate = DateTime.Now.AddHours(2), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = id, Type = "Quest", Text = "Write 1000 Word Essay", Accepted = false, Progress = 0, EndPoint = 1000, EndDate = DateTime.Today.AddDays(7), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = id, Type = "Quest", Text = "Select a Dissertation Topic", Accepted = true, Progress = 1, EndPoint = 1, EndDate = DateTime.Today.AddDays(2), Completed = true}
                };
                _context.AddRange(quests);
            }

            if (_context.AchievementItems.Count() == 0)
            {
                var achievements = new List<AchievementViewModel>
                    {
                        new AchievementViewModel { AchievementID = Guid.NewGuid().ToString(), OwnerID = id, Description = "Attend all lectures in a week", Completed = true, Current = 5, Goal = 5, AssociatedQuests = "Quest", PointsReward = 500 },
                        new AchievementViewModel { AchievementID = Guid.NewGuid().ToString(), OwnerID = id, Description = "Complete 5 Assignments", Completed = false, Current = 4, Goal = 5, AssociatedQuests = "Quest", PointsReward = 500 },
                        new AchievementViewModel { AchievementID = Guid.NewGuid().ToString(), OwnerID = id, Description = "Complete 10 Quests", Completed = false, Current = 8, Goal = 10, AssociatedQuests = "Quest", PointsReward = 500 },
                        new AchievementViewModel { AchievementID = Guid.NewGuid().ToString(), OwnerID = id, Description = "Complete 3 Daily Quests", Completed = false, Current = 1, Goal = 3, AssociatedQuests = "Daily", PointsReward = 500 }
                    };
                _context.AddRange(achievements);
            }

            _context.SaveChanges();
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _context.UserItems.ToList();
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

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
    public class QuestController : Controller
    {
        private readonly LazyDbContext _context;

        public QuestController(LazyDbContext context)
        {
            _context = context;

            if (_context.QuestItems.Count() == 0)
            {
                var users = new List<QuestViewModel>
                {
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = "1001", Type = "Daily" , Text = "Attend all Lectures", Accepted = true, Progress = 1, EndPoint = 3, EndDate = DateTime.Today.AddDays(30), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = "1001", Type = "Quest", Text = "Complete Assignment 1", Accepted = true, Progress = 326, EndPoint = 1000, EndDate = DateTime.Now.AddHours(2), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = "1001", Type = "Quest", Text = "Write 1000 Word Essay", Accepted = false, Progress = 0, EndPoint = 1000, EndDate = DateTime.Today.AddDays(7), Completed = false},
                    new QuestViewModel { QuestID = Guid.NewGuid().ToString(), OwnerID = "1001", Type = "Quest", Text = "Select a Dissertation Topic", Accepted = true, Progress = 1, EndPoint = 1, EndDate = DateTime.Today.AddDays(2), Completed = true}
                };
                _context.AddRange(users);
            }
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("CreateQuests/{id}")]
        public ActionResult GetNew(string  id)
        {
            //Fetch Quest
            //Add them to the Quest Table
            //Return new quests

            return "OK";
        }

        // GET api/<controller>/5
        [HttpGet("GetCurrent/{id}")]
        public ActionResult Get(string id)
        {
            QuestViewModel[] models = _context.QuestItems
                .Where(x => x.OwnerID == id && x.Completed == false && x.EndDate < DateTime.Now)
                .ToArray();

            if (models == null || models.Length == 0)
            {
                return NotFound();
            }

            return new ObjectResult(models);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]QuestViewModel value)
        {
            QuestViewModel quest = _context.QuestItems
                .Where(x => x.OwnerID == value.OwnerID
                && x.QuestID == value.QuestID)
                .First();

            if (quest == null)
                return NotFound();

            QuestUpdate(quest);

            _context.SaveChanges();

            return Ok();
        }

        void QuestUpdate(QuestViewModel quest)
        {
            quest.Progress++;
            if (quest.Progress >= quest.EndPoint)
            {
                quest.Completed = true;
                QuestCompleted(quest);
            }
        }


        void QuestCompleted(QuestViewModel quest)
        {
            AchievementViewModel[] achievements = _context.AchievementItems
                .Where(x => x.OwnerID == quest.OwnerID
                && x.AssociatedQuests == quest.Type)
                .ToArray();

            float amountToAdd = 0;
            var length = achievements.Length;
            for (int i = 0; i < length; i++)
            {
                var achievement = achievements[i];
                achievement.Current++;
                if(achievement.Current >= achievement.Goal)
                {
                    achievement.Completed = true;
                    amountToAdd += achievement.PointsReward;
                }
            }

            if(amountToAdd > 0)
            {
                UserViewModel user = _context.UserItems
                    .Where(x => x.ID == quest.OwnerID)
                    .First();

                if(user != null)
                {
                    user.CurrencyAmount += amountToAdd;
                }
            }
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

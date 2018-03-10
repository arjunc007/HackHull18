using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class AchievementViewModel
    {
        [Key]
        public string AchievementID { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public int Condition { get; set; }
        public bool Completed { get; set; }
        public string AssociatedQuests { get; set; }
    }
}

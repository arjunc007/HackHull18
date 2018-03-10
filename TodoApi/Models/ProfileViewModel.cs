using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ProfileViewModel
    {
        [Key]
        public string OwnerID { get; set; }
        public string RewardID { get; set; }
        public string AchievementID { get; set; }
    }
}

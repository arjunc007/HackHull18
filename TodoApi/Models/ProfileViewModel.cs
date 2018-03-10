using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ProfileViewModel
    {
        public string OwnerID { get; set; }
        public string[] RewardID { get; set; }
        public string[] AchievementID { get; set; }
    }
}

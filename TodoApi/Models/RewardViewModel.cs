using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class RewardViewModel
    {
        [Key]
        public string RewardID { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
    }
}

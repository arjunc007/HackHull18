using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class QuestViewModel
    {
        public string OwnerID { get; set; }
        public string questID { get; set; }
        public string Type { get; set; }
        public int Progress { get; set; }
        public int EndPoint { get; set; }
        public string Text { get; set; }
        public bool Accepted { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
    }
}

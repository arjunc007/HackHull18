using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class QuestContext : DbContext
    {
        public QuestContext(DbContextOptions<QuestContext> options) : base(options)
        {

        }

        public DbSet<QuestViewModel> QuestItems { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class LazyDbContext : DbContext
    {
        public LazyDbContext(DbContextOptions<LazyDbContext> options) : base(options)
        {
        }

        public DbSet<AchievementViewModel> AchievementItems { get; set; }
        public DbSet<CurrencyViewModel> CurrencyItems { get; set; }
        public DbSet<ProfileViewModel> ProfileItems { get; set; }
        public DbSet<QuestViewModel> QuestItems { get; set; }
        public DbSet<RewardViewModel> RewardItem { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<UserViewModel> UserItems { get; set; }
    }
}

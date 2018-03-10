﻿using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<UserViewModel> UserItems { get; set; }
        public DbSet<>
    }
}

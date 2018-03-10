using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions<ProfileContext> options) : base(options)
        {

        }

        public DbSet<ProfileViewModel> ProfileItems { get; set; }
    }
}

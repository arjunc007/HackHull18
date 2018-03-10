using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options)
        {

        }

        public DbSet<CurrencyViewModel> CurrencyItems { get; set; }
    }
}

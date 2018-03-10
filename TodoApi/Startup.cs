
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            DbContextOptions<LazyDbContext> options;
            var builder = new DbContextOptionsBuilder<LazyDbContext>();
            builder.UseSqlite(connection);
            options = builder.Options;

            var context = new LazyDbContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            services.AddDbContext<LazyDbContext>(opt => opt.UseSqlite(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}

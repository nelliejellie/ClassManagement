using ClassManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Api.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public void EnsureDatabaseUpToDate()
        {
            Database.EnsureCreated();
        }
    }
}

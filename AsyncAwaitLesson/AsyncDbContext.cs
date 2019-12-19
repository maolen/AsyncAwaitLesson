using Microsoft.EntityFrameworkCore;

namespace AsyncAwaitLesson
{
    public class AsyncDbContext : DbContext
    {
        public AsyncDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A-104-14;Database=AsyncDb;Trusted_Connection=true;");
        }
    }
}

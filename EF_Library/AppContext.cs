using Microsoft.EntityFrameworkCore;

namespace EF_Library
{
    public class AppContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        public AppContext()
        {

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");

        }
    }
}

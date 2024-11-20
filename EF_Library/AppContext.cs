using Microsoft.EntityFrameworkCore;

namespace EF_Library
{
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
           // optionsBuilder.UseSqlServer(@"Server=192.168.101.159;Database=Reag;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

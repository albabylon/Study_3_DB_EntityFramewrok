using EF_DB_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Book> Books { get; set; }
        
        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=AVE\SQLEXPRESS01;Database=EFLibrary;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

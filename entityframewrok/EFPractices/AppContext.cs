using EFPractices.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library
{
    //Взаимодействие с базой данных в Entity Framework Core происходит посредством специального класса — контекста данных.
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        //public DbSet<Company> Companies { get; set; }

        // Объекты таблицы UserCredentials
        //public DbSet<UserCredential> UserCredentials { get; set; }

        // Объекты таблицы Topics
        public DbSet<Topic> Topics { get; set; }

        public AppContext()
        {
            //Так как изменили модель, мы не сможем просто так соотнести старые таблицы,
            //которые уже были в БД, с новыми моделями.
            //Для этого мы добавили строку для удаления БД при запуске приложения
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //Для настройки подключения
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=AVE\SQLEXPRESS01;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

//DbContext: определяет контекст данных, используемый для взаимодействия с базой данных,
//и является базовым классом для создаваемого контекста вашего приложения.
//DbSet<T>: представляет набор объектов типа T, которые хранятся в определенной таблице БД.
//OnConfiguring: переопределенный метод для настройки подключения к БД.

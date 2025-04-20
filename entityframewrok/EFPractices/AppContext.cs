using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library
{
    //Взаимодействие с базой данных в Entity Framework Core происходит посредством специального класса — контекста данных.
    public class AppContext : DbContext
    {
        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        public AppContext()
        {
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

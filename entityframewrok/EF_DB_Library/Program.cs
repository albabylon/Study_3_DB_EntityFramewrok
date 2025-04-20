using EF_DB_Library.Entities;

namespace EF_DB_Library;

static class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var user1 = new User { Name = "Arthur" };
            var user2 = new User { Name = "Klim" };

            //добавляем данные в таблицу и сохрняем (изменения см. в БД)
            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
        }
    }
}

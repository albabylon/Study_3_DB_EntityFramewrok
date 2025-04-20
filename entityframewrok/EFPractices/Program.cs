namespace EF_DB_Library;
static class Program
{
    static void Main (string[] args)
    {
        using (var db = new AppContext())
        {
            //CREATE
            //добавляем данные в таблицу и сохрняем (изменения см. в БД)
            var user1 = new User { Name = "Arthur", Role = "Admin" };
            var user2 = new User { Name = "Klim", Role = "User" };

            db.Users.Add(user1);
            db.Users.Add(user2);

            //добавляем данные в таблицу
            var user3 = new User { Name = "Alice", Role = "User" };
            var user4 = new User { Name = "Bob", Role = "User" };
            var user5 = new User { Name = "Bruce", Role = "User" };

            // Добавление одиночного пользователя
            db.Users.Add(user3);

            // Добавление нескольких пользователей
            db.Users.AddRange(user4, user5);
            db.SaveChanges();



            //DELETE
            //удаляем данные из таблицы
            db.Users.Remove(user3);
            db.Users.RemoveRange(user4, user5);
            //ИЛИ
            db.Entry(user3).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();



            //READ
            //выбрать из базы объекты, которые не были созданы непосредственно в данной части кода
            //метод ToList(), который отправляет запрос непосредственно в БД и возвращает результат в виде коллекции типа List<T>
            // Выбор всех пользователей
            var allUsersd = db.Users.ToList();

            // Выбор пользователей с ролью "Admin"
            var admins = db.Users.Where(user => user.Role == "Admin").ToList();



            //UPDATE
            // Выбор первого пользователя в таблице
            var firstUser = db.Users.FirstOrDefault();
            firstUser.Email = "simpleemail@gmail.com";
            db.SaveChanges();

            db.SaveChanges();
        }


        //EF обладает функцией отслеживания изменений, соответственно, при добавлении данных в DbSet контекста
        //(используя метод Add) эти данные помечаются состоянием «Added».
        //Это нужно для того, чтобы при сохранении изменений, произведенных в коде,
        //EF смог выбрать те данные, которые были добавлены, и отправить в БД запрос INSERT.

        //Если же данные уже были в БД, то нам нужно выбрать их из базы.
        //Вместе с получением данных из БД EF начинает отслеживать их состояния.

        //о есть с момента, когда данные попали из БД на машину, до вызова метода SaveChanges(),
        //EF будет следить за каждым полученным объектом, и при сохранении создаст один или несколько запросов,
        //чтобы привести состояние данных в базе в соответствие с данными в коде C#.
        //Отслеживание можно отключить, если при запросе использовать AsNoTracking()

        //Когда нам нужно изменить или удалить отслеживаемые объекты, они помечаются состоянием Updated/Deleted,
        //чтобы сформировать UPDATE/DELETE-запрос для отправки в БД.
    }
}

using EFPractices.Entities;

namespace EF_DB_Library;
static class Program
{
    static void Main (string[] args)
    {
        using (var db = new AppContext())
        {
            #region CRUD
            ////CREATE
            ////добавляем данные в таблицу и сохрняем (изменения см. в БД)
            //var user1 = new User { Name = "Arthur", Role = "Admin" };
            //var user2 = new User { Name = "Klim", Role = "User" };

            //db.Users.Add(user1);
            //db.Users.Add(user2);

            ////добавляем данные в таблицу
            //var user3 = new User { Name = "Alice", Role = "User" };
            //var user4 = new User { Name = "Bob", Role = "User" };
            //var user5 = new User { Name = "Bruce", Role = "User" };

            //// Добавление одиночного пользователя
            //db.Users.Add(user3);

            //// Добавление нескольких пользователей
            //db.Users.AddRange(user4, user5);
            //db.SaveChanges();



            ////DELETE
            ////удаляем данные из таблицы
            //db.Users.Remove(user3);
            //db.Users.RemoveRange(user4, user5);
            ////ИЛИ
            //db.Entry(user3).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            //db.SaveChanges();



            ////READ
            ////выбрать из базы объекты, которые не были созданы непосредственно в данной части кода
            ////метод ToList(), который отправляет запрос непосредственно в БД и возвращает результат в виде коллекции типа List<T>
            //// Выбор всех пользователей
            //var allUsersd = db.Users.ToList();

            //// Выбор пользователей с ролью "Admin"
            //var admins = db.Users.Where(user => user.Role == "Admin").ToList();



            ////UPDATE
            //// Выбор первого пользователя в таблице
            //var firstUser = db.Users.FirstOrDefault();
            //firstUser.Email = "simpleemail@gmail.com";
            //db.SaveChanges();

            //db.SaveChanges();
            #endregion

            #region Один к одному
            ////Один к одному
            ////Когда главная сущность ссылается только на один объект зависимой сущности, а зависимая сущность —  на один объект главной.
            ////Пример: Отношение UserCredential и User

            ////Связать объекты сущностей User и UserCredential можно несколькими способами:
            ////1 Через свойство User в объекте класса UserCredential(user1Creds.User = user1);
            ////2 Через свойство UserCredential в объекте класса User(user3.UserCredential = user3Creds);
            ////3 Через передачу Id пользователя в свойство UserId.Данный способ будет работать,
            ////только если у вас есть Id пользователя, и он уже был записан в БД(user2Creds.UserId = user2.Id).

            ////var user1 = new User { Name = "Arthur", Role = "Admin", Email = "" };
            ////var user2 = new User { Name = "Bob", Role = "Admin", Email = "" };
            ////var user3 = new User { Name = "Clark", Role = "User", Email = "" };
            ////var user4 = new User { Name = "Dan", Role = "User", Email = "" };

            ////Добавляем user2 и сохраняем, чтобы получить Id
            ////db.Users.Add(user2);
            ////db.SaveChanges();

            ////db.Users.AddRange(user1, user3, user4);

            ////var user1Creds = new UserCredential { Login = "ArthurL", Password = "qwerty123" };
            ////var user2Creds = new UserCredential { Login = "BobJ", Password = "asdfgh585" };
            ////var user3Creds = new UserCredential { Login = "ClarkK", Password = "111zlt777" };
            ////var user4Creds = new UserCredential { Login = "DanE", Password = "zxc333vbn" };

            ////user1Creds.User = user1;
            ////user2Creds.UserId = user2.Id;
            ////user3.UserCredential = user3Creds;
            ////user4.UserCredential = user4Creds;

            ////Не добавляем user1Creds в БД
            ////db.UserCredentials.AddRange(user2Creds, user3Creds, user4Creds);

            ////db.SaveChanges();
            #endregion

            #region Один ко многоим
            ////Один ко многоим
            ////Первая сущность хранит ссылку только на один объект, а вторая сущность может ссылаться на коллекцию таких объектов первой сущности.
            ////Пример: Отношения — компания и её сотрудники Company - User.

            //var company1 = new Company { Name = "SF" };
            //var company2 = new Company { Name = "VK" };

            //var company3 = new Company { Name = "FB" };
            //db.Companies.Add(company3);
            //db.SaveChanges();

            //var user1 = new User { Name = "Arthur", Role = "Admin", Email = "" };
            //var user2 = new User { Name = "Bob", Role = "Admin", Email = "" };
            //var user3 = new User { Name = "Clark", Role = "User", Email = "" };

            //user1.Company = company1;
            //company2.Users.Add(user2);
            //user3.CompanyId = company3.Id;

            //db.Companies.AddRange(company1, company2);
            //db.Users.AddRange(user1, user2, user3);

            //db.SaveChanges();

            #endregion

            #region Многие ко многим
            //Многие ко многим
            //Когда обе сущности ссылаются на коллекцию объектов другой сущности.
            //Пример: пользователь и его роли. У каждого пользователя может быть множество ролей, и каждая роль может принадлежать множеству пользователей.
            //Или пример: в схеме сущность User — пользователь, и сущность Topic — раздел

            //EF (EF Core) с версии 5.0 позволяет не заботиться о создании связующей таблицы, а разрешает это сам. - НЕ НУЖНА ПРОМЕЖУТОЧНАЯ ТАБЛИЦА

            var topic1 = new Topic { Name = "T1" };
            var topic2 = new Topic { Name = "T2" };
            var topic3 = new Topic { Name = "T3" };

            var user1 = new User { Name = "Arthur", Role = "Admin", Email = "" };
            var user2 = new User { Name = "Bob", Role = "Admin", Email = "" };
            var user3 = new User { Name = "Clark", Role = "User", Email = "" };

            topic1.Users.AddRange(new[] { user1, user2 });
            topic2.Users.AddRange(new[] { user1 });
            topic3.Users.AddRange(new[] { user1, user2, user3 });

            db.Topics.AddRange(new[] { topic1, topic2, topic3 });
            db.Users.AddRange(new[] { user1, user2, user3 } );
            
            db.SaveChanges();

            #endregion
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

using EF_DB_Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public void UpdateName(int userId, string userName)
        {
            var book = dbSet.FirstOrDefault(x => x.Id == userId);
            if (book != null)
                book.Name = userName;
            context.SaveChanges();
        }

        public void GetBook(int userId, string userName)
        {

        }
    }
}

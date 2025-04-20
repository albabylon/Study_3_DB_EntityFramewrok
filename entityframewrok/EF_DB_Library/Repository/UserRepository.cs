using EF_DB_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.Repository
{
    public class UserRepository : BaseRepository<Book, int>
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
    }
}

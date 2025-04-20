using EF_DB_Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public class BookRepository : BaseRepository<Book, int>
    {
        public BookRepository(DbContext context) : base(context)
        {

        }

        public void UpdateReleaseYear(int userId, DateTime dateTime)
        {
            var book = dbSet.FirstOrDefault(x => x.Id == userId);
            if (book != null)
                book.ReleaseYear = dateTime;
            context.SaveChanges();
        }
    }
}

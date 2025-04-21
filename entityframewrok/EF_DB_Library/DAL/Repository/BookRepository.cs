using EF_DB_Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public class BookRepository : BaseRepository<Book, int>
    {
        public BookRepository(DbContext context) : base(context)
        {

        }

        public async Task UpdateReleaseYear(int userId, DateTime dateTime)
        {
            var book = await dbSet.FirstOrDefaultAsync(x => x.Id == userId);
            if (book != null)
                book.ReleaseYear = dateTime;
            await context.SaveChangesAsync();
        }

        public async Task<Book?> GetBook(int userId, string bookName)
        {
            return await dbSet
                .Where(x => x.Name == bookName)
                .Where(x => x.Users.Any(u => u.Id == userId))
                .FirstOrDefaultAsync();
        }
    }
}

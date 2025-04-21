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

        public async Task<IEnumerable<Book>> SelectBooksByGenreBetweenYears(string genre, DateTime firstYear, DateTime lastYear)
        {
            return await dbSet
                .Where(b => b.Genre == genre)
                .Where(b => b.ReleaseYear > firstYear && b.ReleaseYear < lastYear)
                .ToListAsync();
        }

        public async Task<int> CountBooksByAuthor(string authorName)
        {
            var books = await dbSet
                .Include(a => a.Author)
                .Where(b => b.Author.Name == authorName)
                .ToListAsync();
           
            return books.Count;
        }

        public async Task<int> CountBooksByGenre(string genre)
        {
            var books = await dbSet
                .Where(b => b.Genre == genre)
                .ToListAsync();

            return books.Count;
        }

        public async Task<bool> IsBookThisAuthorThisName(string authorName, string bookName)
        {
            return await dbSet
                .Include(a => a.Author)
                .Where(b => b.Author.Name == authorName)
                .AnyAsync(b => b.Name == bookName);
        }

        public async Task<Book?> LastRealeseBook() =>
            await dbSet.OrderByDescending(b => b.ReleaseYear).FirstOrDefaultAsync();

        public async Task<IEnumerable<Book>> SelectOrderByName() => 
            await dbSet.OrderBy(b => b.Name).ToListAsync();

        public async Task<IEnumerable<Book>> SelectOrderByDescName() =>
            await dbSet.OrderByDescending(b => b.ReleaseYear).ToListAsync();
    }
}

using EF_DB_Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public async Task UpdateName(int userId, string userName)
        {
            var user = await dbSet.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
                user.Name = userName;
            await context.SaveChangesAsync();
        }

        public async Task GetBook(int userId, string bookName, IEnumerable<Book> enableBooks)
        {
            var book = enableBooks.FirstOrDefault(b => b.Name == bookName) ??
                throw new Exception("Книга не найдена!");

            var user = await dbSet.FirstOrDefaultAsync(u => u.Id == userId) ??
                throw new Exception("Юзер не найдена!");

            user.Books.Add(book);
        }
    }
}

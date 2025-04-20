using EF_DB_Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.Repository
{
    public class BookRepository<TEntity, TKey> : BaseRepository<TEntity, TKey> where TEntity : class
    {
        public BookRepository(DbContext context) : base(context)
        {

        }

        public void UpdateReleaseYear(Book book)
        {
            dbSet.Where(predicate).Update(entity);
            context.SaveChanges();
        }
    }
}

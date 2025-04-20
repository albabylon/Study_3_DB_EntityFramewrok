using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.Repository
{
    public class BaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        protected TEntity SelectById(TKey id)
        {
            return dbSet.Find(id);
        }

        protected IEnumerable<TEntity> SelectAll(TEntity table)
        {
            return dbSet.ToList();
        }

        protected void Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        protected void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}

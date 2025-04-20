using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
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

        public TEntity SelectById(TKey id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> SelectAll(TEntity table)
        {
            return dbSet.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }
    }
}

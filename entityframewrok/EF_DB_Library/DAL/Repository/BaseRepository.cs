using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public abstract class BaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;

        protected BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> SelectById(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAll()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.Repository
{
    public class UserRepository<TEntity, TKey> : BaseRepository<TEntity, TKey> where TEntity : class
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public void UpdateName<T>(int id)
        {
            using var db = new AppContext();
        }
    }
}

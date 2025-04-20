namespace EF_DB_Library.Repository
{
    public class BaseRepository
    {        
        protected T SelectById<T>(int id)
        {
            using var db = new AppContext();
        }

        protected IEnumerable<T> SelectAll<T>(T table)
        {
            using var db = new AppContext();
        }

        protected void Add<T>()
        {
            using var db = new AppContext();
        }

        protected void Delete<T>()
        {
            using var db = new AppContext();
        }
    }
}

namespace EF_DB_Library.Repository
{
    public class BookRepository
    {
        public void UpdateReleaseYear<T>(int id)
        {
            using var db = new AppContext();
        }
    }
}

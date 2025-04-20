namespace EF_DB_Library;

static class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var bookrep = new BookRepository(db);
        }
    }
}

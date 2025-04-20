using EF_DB_Library.Repository;

namespace EF_DB_Library;

static class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var bookRepos = new BookRepository(db);

            var userRepos = new UserRepository(db);
        }
    }
}

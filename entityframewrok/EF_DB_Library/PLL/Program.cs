using EF_DB_Library.DAL.Entities;
using EF_DB_Library.DAL.Repository;

namespace EF_DB_Library.PLL;
static class Program
{
    static async Task Main(string[] args)
    {
        using (var db = new DAL.AppContext())
        {
            var userRepos = new UserRepository(db);
            var authorRepos = new AuthorRepository(db);
            var bookRepos = new BookRepository(db);

            //await CreateData(userRepos, authorRepos, bookRepos);

            var books = await bookRepos.SelectAll();

            await userRepos.GetBook(5, "Книга 4", books);

            await db.SaveChangesAsync();
        }
    }

    private static async Task CreateData(UserRepository userRepos, AuthorRepository authorRepos, BookRepository bookRepos)
    {
        var user1 = await userRepos.Add(new User { Name = "Юзер 1" });
        var user2 = await userRepos.Add(new User { Name = "Юзер 2" });
        var user3 = await userRepos.Add(new User { Name = "Юзер 3" });
        var user4 = await userRepos.Add(new User { Name = "Юзер 4" });
        var user5 = await userRepos.Add(new User { Name = "Юзер 5" });

        var author1 = await authorRepos.Add(new Author { Name = "Автор 1" });
        var author2 = await authorRepos.Add(new Author { Name = "Автор 2" });

        var book1 = await bookRepos.Add(new Book { Name = "Книга 1", ReleaseYear = new DateTime(2001, 12, 1), Genre = "Автобиография", AuthorId = author1.Id });
        var book2 = await bookRepos.Add(new Book { Name = "Книга 2", ReleaseYear = new DateTime(1983, 10, 31), Genre = "Детектив", AuthorId = author1.Id });
        var book3 = await bookRepos.Add(new Book { Name = "Книга 3", ReleaseYear = new DateTime(1782, 01, 22), Genre = "Истрория", AuthorId = author2.Id });
        var book4 = await bookRepos.Add(new Book { Name = "Книга 4", ReleaseYear = new DateTime(2022, 02, 12), Genre = "Рассказ", AuthorId = author2.Id });

        author1.Books.AddRange(new[] { book1, book2 });
        author2.Books.AddRange(new[] { book3, book4 });

        user1.Books.AddRange(new[] { book1, book2, book3, book4 });
        user2.Books.AddRange(new[] { book1, book2, book3 });
        user3.Books.AddRange(new[] { book1, book2 });
        user4.Books.AddRange(new[] { book1 });
        user5.Books.AddRange(new[] { book1 });

        book1.Users.AddRange(new[] { user1, user2, user3, user4, user5 });
        book2.Users.AddRange(new[] { user1, user2, user3, user4 });
        book3.Users.AddRange(new[] { user1, user2, user3 });
        book4.Users.AddRange(new[] { user1, user2 });
    }
}

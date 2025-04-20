using EF_DB_Library.DAL.Entities;
using EF_DB_Library.DAL.Repository;

namespace EF_DB_Library.PLL;
static class Program
{
    static void Main(string[] args)
    {
        using (var db = new DAL.AppContext())
        {
            var userRepos = new UserRepository(db);
            var user1 = userRepos.Add(new User { Name = "Юзер 1" });
            var user2 = userRepos.Add(new User { Name = "Юзер 2" });
            var user3 = userRepos.Add(new User { Name = "Юзер 3" });
            var user4 = userRepos.Add(new User { Name = "Юзер 4" });
            var user5 = userRepos.Add(new User { Name = "Юзер 5" });

            var authorRepos = new AuthorRepository(db);
            var author1 = authorRepos.Add(new Author { Name = "Автор 1" });
            var author2 = authorRepos.Add(new Author { Name = "Автор 2" });

            var bookRepos = new BookRepository(db);
            var book1 = bookRepos.Add(new Book { Name = "Книга 1", ReleaseYear = new DateTime(2001, 12, 1), Genre = "Автобиография" });
            var book2 = bookRepos.Add(new Book { Name = "Книга 2", ReleaseYear = new DateTime(1983, 10, 31), Genre = "Детектив" });
            var book3 = bookRepos.Add(new Book { Name = "Книга 3", ReleaseYear = new DateTime(1782, 01, 22), Genre = "Истрория" });
            var book4 = bookRepos.Add(new Book { Name = "Книга 4", ReleaseYear = new DateTime(2022, 02, 12), Genre = "Рассказ" });

            author1.Books.AddRange(new[] { book1, book2 });
            author2.Books.AddRange(new[] { book3, book4 });

            book1.Users.AddRange(new[] { user1, user2, user3, user4, user5 });
            book2.Users.AddRange(new[] { user1, user2, user3, user4 });
            book3.Users.AddRange(new[] { user1, user2, user3 });
            book4.Users.AddRange(new[] { user1, user2 });
        }
    }
}

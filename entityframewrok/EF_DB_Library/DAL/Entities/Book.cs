using System.ComponentModel.DataAnnotations.Schema;

namespace EF_DB_Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Genre { get; set; }

        public DateTime ReleaseYear { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}

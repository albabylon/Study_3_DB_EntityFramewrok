﻿namespace EF_DB_Library.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}

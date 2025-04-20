﻿namespace EF_DB_Library.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}

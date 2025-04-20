using EF_DB_Library.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DB_Library.DAL.Repository
{
    public class AuthorRepository : BaseRepository<Author, int>
    {
        public AuthorRepository(DbContext context) : base(context)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DB_Library.Repository
{
    public class UserRepository
    {
        public void UpdateName<T>(int id)
        {
            using var db = new AppContext();
        }
    }
}

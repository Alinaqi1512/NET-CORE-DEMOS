using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Data.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private LibraryContext _db;
        public ApplicationUserRepository(LibraryContext db): base(db)
        {
            _db=db;
        }
    }
}

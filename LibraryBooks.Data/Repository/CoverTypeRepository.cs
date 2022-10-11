using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Data.Repository
{
    public class CoverTypeRepository: Repository<CoverType>, ICoverTypeRepository
    {
        private LibraryContext _db;
        public CoverTypeRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CoverType coverType)
        {
            _db.coverTypes.Update(coverType);
        }
    }
}

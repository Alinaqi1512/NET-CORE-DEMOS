using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Data.Repository
{
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        private LibraryContext _db;
        public CompanyRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Company company)
        {
            _db.Companies.Update(company);
        }      
    }
}

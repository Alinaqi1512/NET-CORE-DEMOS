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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private LibraryContext _db;
        public CategoryRepository(LibraryContext db): base(db)
        {
            _db=db;
        }
       

        public void Update(Category category)
        {
            _db.categories.Update(category);
        }
    }
}

using LibraryBooks.Data.Repository.IRepository;
using LibraryBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Data.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private LibraryContext _db;
        public ProductRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(p => p.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Author = obj.Author;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.CategoryId = obj.CategoryId;
                obj.CoverTypeId = obj.CoverTypeId;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                if(objFromDb.ImageUrl == null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
           // _db.Products.Update(productRepository);
        }
    }
}

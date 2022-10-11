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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private LibraryContext _db;
        public OrderDetailRepository(LibraryContext db): base(db)
        {
            _db=db;
        }       
        public void Update(OrderDetail orderDetail)
        {
            _db.OrderDetails.Update(orderDetail);
        }
    }
}

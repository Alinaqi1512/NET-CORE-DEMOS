using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Model.View_Models
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> cartList { get; set; }
      
        public OrderHeader OrderHeader { get; set; }
    }
}

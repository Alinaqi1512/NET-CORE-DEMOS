﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Model
{
	public class OrderDetail
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }
		public int ProductsId { get; set; }
		[ForeignKey("ProductsId")]
        [ValidateNever]

        public Product Product { get; set; }
		public int Count { get; set; }
		public double Price { get; set; }
	}
}

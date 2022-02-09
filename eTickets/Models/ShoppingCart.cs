﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class ShoppingCart
	{
		public int Id { get; set; }
		public string AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public ICollection<ShoppingCartItem> CartItems { get; set; }


	}
}

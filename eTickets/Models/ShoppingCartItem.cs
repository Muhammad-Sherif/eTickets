using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }
		public int Amount { get; set; }
		public Movie Movie { get; set; }
		public int MovieId { get; set; }

		public int ShoppingCartId { get; set; }
		public ShoppingCart ShoppingCart { get; set; }


	}
}

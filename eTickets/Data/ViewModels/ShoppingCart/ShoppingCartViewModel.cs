using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.ShoppingCart
{
	public class ShoppingCartViewModel
	{
		public int Id { get; set; }
		public double TotalPrice { get; set; }
		public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItem { get; set; }


	}
}

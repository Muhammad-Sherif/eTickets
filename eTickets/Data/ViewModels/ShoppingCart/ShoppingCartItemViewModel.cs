using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.ShoppingCart
{
	public class ShoppingCartItemViewModel
	{
		public int Amount { get; set; }
		public int MovieId { get; set; }
		public string MoveName { get; set; }

		public double MoviePrice { get; set; }



	}
}

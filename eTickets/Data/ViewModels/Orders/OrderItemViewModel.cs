using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Orders
{
	public class OrderItemViewModel
	{
		public int Amount { get; set; }
		public string MovieName { get; set; }
		public double MoviePrice { get; set; }

	}
}

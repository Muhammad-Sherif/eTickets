using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Orders
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public double TotalPrice { get; set; }
		public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
	}
}

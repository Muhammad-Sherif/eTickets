using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class OrderItem
	{
		public int Id { get; set; }
		public int Amount { get; set; }
		public string MovieName { get; set; }
		public double MoviePrice { get; set; }
		public int OrderId{ get; set; }
		public Order Order { get; set; }

	}
}

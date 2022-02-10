using eTickets.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewComponents
{
	public class ShoppingCartSummaryViewComponent : ViewComponent
	{
		public IUnitOfWork _context { get; set; }

		public ShoppingCartSummaryViewComponent(IUnitOfWork context)
		{
			_context = context;
		}

		

		public IViewComponentResult Invoke(string userId)
		{
			var shopppingCart =  _context.ShoppingCarts.FirstOrDefault(sc => sc.AppUserId == userId);
			var cartItemsCount = _context.ShoppingCartItems.Count(ci => ci.ShoppingCartId == shopppingCart.Id);
			return View(cartItemsCount);

		}
	}
}

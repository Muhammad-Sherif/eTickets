using AutoMapper;
using eTickets.Data.Enums;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.ViewModels.Orders;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	[Authorize(Roles = nameof(UserRoles.User))]

	public class OrdersController : Controller
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;

		public OrdersController(IUnitOfWork context, IMapper mapper, IToastNotification toastr)
		{
			_context = context;
			_mapper = mapper;
			_toastr = toastr;
		}
		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var Order = await _context.Orders.FindAsync(sc => sc.AppUserId == userId , o=>o.OrderItems);
			var orderViewModel = _mapper.Map<List<OrderViewModel>>(Order);
			return View(orderViewModel);
		}

		public async Task<IActionResult> Compelete()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(sc => sc.AppUserId == userId);
			shoppingCart.CartItems = _context.ShoppingCartItems.Find(ci => ci.ShoppingCartId == shoppingCart.Id, ci => ci.Movie);
			if (shoppingCart.CartItems.Count() == 0)
			{
				_toastr.AddWarningToastMessage("Please add movies!");
				Redirect(Url.Action("Index", "ShoppingCart"));
			}

			var order = _mapper.Map<Order>(shoppingCart);
			_context.Orders.Add(order);
			_context.ShoppingCartItems.DeleteRange(shoppingCart.CartItems);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Order completed successfully");
			return Redirect(nameof(Index));
		}

	}
}

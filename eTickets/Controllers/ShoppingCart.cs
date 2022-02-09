using AutoMapper;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.Services.Interfaces;
using eTickets.Data.ViewModels.ShoppingCart;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	public class ShoppingCartController : Controller
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;
		private readonly IShoppingCartService _shoppingCartService;

		


		public ShoppingCartController(IUnitOfWork context, IMapper mapper, IShoppingCartService shoppingCartService, IToastNotification toastr)
		{
			_context = context;
			_mapper = mapper;
			_shoppingCartService = shoppingCartService;
			_toastr = toastr;
		}


		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(sc => sc.AppUserId == userId);
			shoppingCart.CartItems = _context.ShoppingCartItems.Find(ci => ci.ShoppingCartId == shoppingCart.Id , ci=>ci.Movie);
			var shoppingCartViewModel = _mapper.Map<ShoppingCartViewModel>(shoppingCart);
			return View(shoppingCartViewModel);

		}
		public IActionResult AddItem(int movieId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var shoppingCart = _shoppingCartService.GetUserShoppingCart(userId);
			_shoppingCartService.AddItemToShoppingCart(shoppingCart, movieId);
			_toastr.AddSuccessToastMessage("Movie added successfully");
			return RedirectToAction(nameof(Index));
		}

		public IActionResult RemoveItem(int movieId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var shoppingCart = _shoppingCartService.GetUserShoppingCart(userId);
			_shoppingCartService.RemoveItemFromShoppingCart(shoppingCart, movieId);
			_toastr.AddSuccessToastMessage("Movie removed successfully");
			return RedirectToAction(nameof(Index));
		}


	}
}

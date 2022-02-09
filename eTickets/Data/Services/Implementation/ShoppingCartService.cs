using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.Services.Interfaces;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Implementation
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IUnitOfWork _context;

		public ShoppingCartService(IUnitOfWork context)
		{
			_context = context;
		}

		public void AddItemToShoppingCart(ShoppingCart shoppingCart, int movieId)
		{
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(sc => sc.ShoppingCartId == shoppingCart.Id && sc.MovieId == movieId);
			if (shoppingCartItem != null)
				shoppingCartItem.Amount++;
			else
			{
				shoppingCartItem = new ShoppingCartItem() {
					Amount = 1, MovieId = movieId, ShoppingCartId = shoppingCart.Id };
				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			_context.SaveChanges();

		}

		public ShoppingCart GetUserShoppingCart(string userId)
		{
			var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.AppUserId == userId);

			if (shoppingCart == null)
			{
				shoppingCart = new ShoppingCart() { AppUserId = userId };
				_context.ShoppingCarts.Add(shoppingCart);
				_context.SaveChanges();
			}

			return shoppingCart;
		}

		public void RemoveItemFromShoppingCart(ShoppingCart shoppingCart, int movieId)
		{
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(sc => sc.ShoppingCartId == shoppingCart.Id && sc.MovieId == movieId);
			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 0)
					shoppingCartItem.Amount--;

				if (shoppingCartItem.Amount == 0)
					_context.ShoppingCartItems.Delete(shoppingCartItem);


				_context.SaveChanges();

			}
			
		}
	}
}

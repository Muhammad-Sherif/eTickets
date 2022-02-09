using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Interfaces
{
	public interface IShoppingCartService
	{
		ShoppingCart GetUserShoppingCart(string userId);

		void AddItemToShoppingCart(ShoppingCart shoppingCart  , int movieId);
		void RemoveItemFromShoppingCart(ShoppingCart shoppingCart, int movieId);
		//void DeleteUserShoppingCart(ShoppingCart shoppingCart , string movieId);



	}
}

using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repositories.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Movie> Movies { get;}
		IGenericRepository<Cinema> Cinemas { get;}
		IGenericRepository<Actor> Actors { get;}
		IGenericRepository<Genre> Genres { get;}
		IGenericRepository<MoviesActors> MoviesActors { get; }
		IGenericRepository<MoviesGenres> MoviesGenres { get; }
		IGenericRepository<ShoppingCart> ShoppingCarts { get;}
		IGenericRepository<ShoppingCartItem> ShoppingCartItems { get; }
		IGenericRepository<Order> Orders { get; }
		IGenericRepository<OrderItem> OrderItems { get; }

		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}


using eTickets.Data.Repositories.Interfaces;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repositories.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		public IGenericRepository<Movie> Movies { get; private set; }

		public IGenericRepository<Cinema> Cinemas { get; private set; }

		public IGenericRepository<Actor> Actors { get; private set; }

		public IGenericRepository<Genre> Genres { get; private set; }
		public IGenericRepository<MoviesActors> MoviesActors  { get; private set; }
		public IGenericRepository<MoviesGenres> MoviesGenres { get; private set; }
		public IGenericRepository<ShoppingCart> ShoppingCarts { get; private set; }
		public IGenericRepository<ShoppingCartItem> ShoppingCartItems { get; private set; }

		public UnitOfWork(AppDbContext context)
		{
			_context = context;
			Movies = new GenericRepository<Movie>(_context);
			Actors = new GenericRepository<Actor>(_context);
			Genres= new GenericRepository<Genre>(_context);
			Cinemas = new GenericRepository<Cinema>(_context);
			MoviesActors = new GenericRepository<MoviesActors>(_context);
			MoviesGenres = new GenericRepository<MoviesGenres>(_context);
			ShoppingCarts = new GenericRepository<ShoppingCart>(_context);
			ShoppingCartItems = new GenericRepository<ShoppingCartItem>(_context);


		}
		public void Dispose()
		{
			_context.Dispose();
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		
	}
}

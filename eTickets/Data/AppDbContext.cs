using eTickets.Configurations.EntitiesConfigrations;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace eTickets.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Movie> Movies { get; set; }
		public DbSet<Cinema> Cinemas { get; set; }
		public DbSet<Actor> Actors{ get; set; }
		public DbSet<Genre> Genres{ get; set; }
		public DbSet<MoviesActors> MoviesActors { get; set; }
		public DbSet<MoviesGenres> MoviesGenres { get; set; }

	}
}

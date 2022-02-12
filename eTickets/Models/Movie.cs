using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Story { get; set; }

		public Double Price { get; set; }
		public byte[] Poster { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int Minutes { get; set; }

		public int CinemaId { get; set; }
		public Cinema Cinema { get; set; }


		public ICollection<MoviesGenres> MoviesGenres { get; set; }
		public ICollection<Genre> Genres { get; set; }

		public ICollection<MoviesActors> MoviesActors { get; set; }
		public ICollection<Actor> Actors{ get; set; }
	}
}

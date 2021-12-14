using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class Genre
	{
		public int Id { get; set; }
		public int Name { get; set; }
		public ICollection<Movie> Movies{ get; set; }
		public ICollection<MoviesGenres> MoviesGenres { get; set; }


	}
}

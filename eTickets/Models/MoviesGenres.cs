using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class MoviesGenres
	{
		public int MoiveId { get; set; }
		public Movie Movie { get; set; }

		public int GenreId{ get; set; }
		public Genre Genre{ get; set; }

		


	}
}

using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Movies
{
	public class MovieDetailsViewModel
	{
		public int Id{ get; set; }
		public string Name { get; set; }
		public string Story { get; set; }
		public Cinema Cinema { get; set; }
		public int Minutes { get; set; }
		public ICollection<Genre> Genres { get; set; }
		public ICollection<Actor> Actors { get; set; }
		public Double Price { get; set; }
		public byte[] Poster { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}

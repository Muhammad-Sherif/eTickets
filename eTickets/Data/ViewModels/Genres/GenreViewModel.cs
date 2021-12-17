using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Genres
{
	public class GenreViewModel
	{
		public int Id { get; set; }
		[MaxLength(3)]
		public string Name { get; set; }

	}
}

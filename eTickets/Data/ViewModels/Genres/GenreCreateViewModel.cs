using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Genres
{
	public class GenreCreateViewModel
	{
		[Required]
		[StringLength(250)]
		public string Name { get; set; }

	}
}

using eTickets.Data.CustomDataAnnotation;
using eTickets.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Movies
{
	public class MovieCreateViewModel
	{
		[Required, StringLength(250)]

		public string Name { get; set; }
		[Required, StringLength(2500)]

		public string Story { get; set; }
		[Required]
		[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
		[Range(0, 9999999999.99, ErrorMessage = "Invalid Target Price; Max 10 digits")]
		public Double Price { get; set; }
		[Required]
		[AllowedExtensions(new string[] { ".png", ".jpg" }, ErrorMessage = ".png and .jpg extentions are only allowed")]
		[MaxFileSize(2)]
		public IFormFile Poster { get; set; }

		[Required , Display(Name = "Start Date")]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }

		[Required, Display(Name = "End Date")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
		[Required , Display(Name="Genres")]
		public IList<int> GenresIds { get; set; }
		public IEnumerable<Genre> Genres { get; set; }

		[Required, Display(Name = "Actors")]
		public IList<int> ActorsIds { get; set; }
		public IEnumerable<Actor> Actors { get; set; }

		[Required , Display(Name= "Cinemas")]
		public int CinemaId { get; set; }
		public IEnumerable<Cinema> Cinemas { get; set; }




	}
}

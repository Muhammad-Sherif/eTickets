using eTickets.Data.CustomDataAnnotation;
using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Movies
{
	public class MovieEditViewModel
	{
		[Required, HiddenInput]
		public int Id { get; set; }
		[Required, StringLength(250)]

		public string Name { get; set; }
		[Required, Display(Name = "Film Durations(Minutes)")]
		public int Minutes { get; set; }
		[Required, StringLength(2500)]

		public string Story { get; set; }
		[Required ]
		[RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
		[Range(0, 9999999999.99, ErrorMessage = "Invalid Target Price; Max 10 digits")]
		public Double Price { get; set; }
		[AllowedExtensions(new string[] { ".png", ".jpg" }, ErrorMessage = ".png and .jpg extentions are only allowed")]
		[MaxFileSize(2)]
		public IFormFile PosterFile { get; set; }
		public byte[] Poster { get; set; }
		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required, Display(Name = "Genres")]
		public IList<int> GenresIds { get; set; }
		public IEnumerable<Genre> Genres { get; set; }

		[Required, Display(Name = "Actors")]
		public IList<int> ActorsIds { get; set; }
		public IEnumerable<Actor> Actors { get; set; }

		[Required, Display(Name = "Cinemas")]
		public int CinemaId { get; set; }
		public IEnumerable<Cinema> Cinemas { get; set; }

	}
}

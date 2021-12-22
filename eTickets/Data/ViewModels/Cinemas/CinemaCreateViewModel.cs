using eTickets.Data.CustomDataAnnotation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Cinemas
{
	public class CinemaCreateViewModel
	{
		[Required, StringLength(250)]
		public string Name { get; set; }
		[Required, StringLength(2500)]
		public string Description { get; set; }
		[Display(Name = "Cinema Logo")]
		[Required(ErrorMessage = "Cinema Logo is required")]
		[AllowedExtensions(new string[] { ".png", ".jpg" }, ErrorMessage = ".png and .jpg extentions are only allowed")]
		[MaxFileSize(2)]
		public IFormFile Logo { get; set; }

	}
}

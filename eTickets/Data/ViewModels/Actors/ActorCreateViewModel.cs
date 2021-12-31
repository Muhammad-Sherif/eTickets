using eTickets.Data.CustomDataAnnotation;
using eTickets.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Actors
{
	public class ActorCreateViewModel
	{
		[Required, StringLength(250)]
		public string FirstName { get; set; }
		[Required, StringLength(250)]
		public string LastName { get; set; }
		[Required, StringLength(2500)]
		public string Bio { get; set; }
		[Display(Name ="Actor Image")]
		[Required(ErrorMessage ="Actor image is required")]
		[AllowedExtensions(new string[] { ".png" , ".jpg"},ErrorMessage =".png and .jpg extentions are only allowed")]
		[MaxFileSize(2)]
		public IFormFile ImageFile { get; set; }

	}
}

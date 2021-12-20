using eTickets.Data.CustomDataAnnotation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Actors
{
	public class ActorEditViewModel
	{
		[Required , HiddenInput] 
		public int Id { get; set; }
		[Required, StringLength(250)]
		public string FirstName { get; set; }
		[Required, StringLength(250)]
		public string LastName { get; set; }
		[Required, StringLength(2500)]
		public string Bio { get; set; }
		[Display(Name = "Actor Image")]
		[AllowedExtensions(new string[] { ".png", ".jpg" }, ErrorMessage = ".png and .jpg extentions are only allowed")]
		[MaxFileSize(2)]
		public IFormFile ImageFile { get; set; }
		public Byte[] Image { get; set; }


	}
}

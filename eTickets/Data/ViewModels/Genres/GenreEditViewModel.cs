
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels.Genres
{
	public class GenreEditViewModel
	{
		[Required]
		[HiddenInput]
		public int Id { get; set; }
		[Required]
		[StringLength(250)]
		public string Name { get; set; }
	}
}

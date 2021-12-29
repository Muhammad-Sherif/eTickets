using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
	public class Actor
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[NotMapped]
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}
		public string Bio { get; set; }
		public byte[] Image { get; set; }

		public ICollection<Movie> Movies { get; set; }
		public ICollection<MoviesActors> MoviesActors { get; set; }
	}
}

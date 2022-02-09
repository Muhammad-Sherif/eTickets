using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigrations
{
	public class GenreConfigurations : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			TableConfigurations(builder);
		}
		private void TableConfigurations(EntityTypeBuilder<Genre> builder)
		{
			builder.Property(g => g.Name).IsRequired().HasMaxLength(250);
		}
	}
}

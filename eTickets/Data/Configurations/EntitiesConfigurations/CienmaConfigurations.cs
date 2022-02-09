using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class CienmaConfigurations : IEntityTypeConfiguration<Cinema>
	{
		public void Configure(EntityTypeBuilder<Cinema> builder)
		{
			TableConfigurations(builder);
		}
		private void TableConfigurations(EntityTypeBuilder<Cinema> builder)
		{
			builder.Property(c => c.Name).IsRequired().HasMaxLength(250);
			builder.Property(c => c.Description).IsRequired().HasMaxLength(2500);
			builder.Property(c => c.Logo).IsRequired();

		}
	}

}

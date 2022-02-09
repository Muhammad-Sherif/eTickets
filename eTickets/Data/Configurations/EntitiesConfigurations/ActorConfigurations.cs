using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class ActorConfiguration : IEntityTypeConfiguration<Actor>
	{
		public void Configure(EntityTypeBuilder<Actor> builder)
		{
			TableConfigurations(builder);
		}

		private void TableConfigurations(EntityTypeBuilder<Actor> builder)
		{
			builder.Property(a => a.FirstName).IsRequired().HasMaxLength(250);
			builder.Property(a => a.LastName).IsRequired().HasMaxLength(250);
			builder.Property(a => a.Bio).IsRequired().HasMaxLength(2500);
			builder.Property(a => a.Image).IsRequired();

		}
	}
}
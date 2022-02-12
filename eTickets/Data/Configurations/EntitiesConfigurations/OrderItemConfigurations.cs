using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			EntityConfigurations(builder);
		}

		private void EntityConfigurations(EntityTypeBuilder<OrderItem> builder)
		{
			builder.Property(m => m.MoviePrice).IsRequired().HasColumnType("decimal").HasPrecision(10,2);
			builder.Property(m => m.MovieName).IsRequired().HasMaxLength(250);




		}
	}
}

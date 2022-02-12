using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			TableConfigurations(builder);
			RelationsConfigurations(builder);
		}
		private void TableConfigurations(EntityTypeBuilder<Order> builder)
		{
			builder.Property(sc => sc.AppUserId).IsRequired().HasMaxLength(450);
			builder.HasIndex(ci => ci.AppUserId).IsUnique(false);


		}
		private void RelationsConfigurations(EntityTypeBuilder<Order> builder)
		{

			builder.HasMany(sc => sc.OrderItems)
				.WithOne(ci => ci.Order)
				.HasForeignKey(ci => ci.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasOne(sc => sc.AppUser)
				.WithOne()
				.HasForeignKey<Order>(sc => sc.AppUserId)
				.OnDelete(DeleteBehavior.Cascade);


		}
	}
}

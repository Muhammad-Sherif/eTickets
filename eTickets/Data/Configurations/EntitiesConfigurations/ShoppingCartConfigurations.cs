using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
	{
		public void Configure(EntityTypeBuilder<ShoppingCart> builder)
		{
			TableConfigurations(builder);
			RelationsConfigurations(builder);	
		}
		private void TableConfigurations(EntityTypeBuilder<ShoppingCart> builder)
		{
			builder.Property(sc => sc.AppUserId).IsRequired().HasMaxLength(450);

		}
		private void RelationsConfigurations(EntityTypeBuilder<ShoppingCart> builder)
		{
			builder.HasMany(sc=>sc.CartItems)
				.WithOne(ci=>ci.ShoppingCart)
				.HasForeignKey(ci=>ci.ShoppingCartId)
				.OnDelete(DeleteBehavior.Cascade);

			builder
				.HasOne(sc => sc.AppUser)
				.WithOne()
				.HasForeignKey<ShoppingCart>(sc => sc.AppUserId)
				.OnDelete(DeleteBehavior.Cascade);


		}
	}
}

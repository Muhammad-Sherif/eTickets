using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigurations
{
	public class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
	{
		public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
		{
			RelationsConfigurations(builder);	
		}
		
		private void RelationsConfigurations(EntityTypeBuilder<ShoppingCartItem> builder)
		{
			
			builder
				.HasOne(ci => ci.Movie)
				.WithOne()
				.HasForeignKey<ShoppingCartItem>(ci => ci.MovieId)
				.OnDelete(DeleteBehavior.Cascade);


		}
	}
}

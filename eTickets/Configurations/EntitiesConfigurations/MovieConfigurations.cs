using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Configurations.EntitiesConfigrations
{
	public class MovieConfigurations : IEntityTypeConfiguration<Movie>
	{

		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			TableConfigurations(builder);
			RelationsConfigurations(builder);
		}
		private void RelationsConfigurations(EntityTypeBuilder<Movie> builder)
		{
			builder
				.HasOne(m => m.Cinema)
				.WithMany(c => c.Movies)
				.HasForeignKey(m => m.CinemaId)
				.OnDelete(DeleteBehavior.Restrict);


			builder
				.HasMany(m => m.Actors)
				.WithMany(a => a.Movies)
				.UsingEntity<MoviesActors>(
					j => j
					.HasOne(ma => ma.Actor)
					.WithMany(a => a.MoviesActors)
					.HasForeignKey(ma => ma.ActorId)
					.OnDelete(DeleteBehavior.Restrict),
					j => j
					.HasOne(ma => ma.Movie)
					.WithMany(m => m.MoviesActors)
					.HasForeignKey(ma => ma.MoiveId)
					.OnDelete(DeleteBehavior.Cascade),
					j => j
					.HasKey(t => new { t.ActorId, t.MoiveId })
					);


			builder
				.HasMany(m => m.Genres)
				.WithMany(g => g.Movies)
				.UsingEntity<MoviesGenres>(
					j => j
					.HasOne(mg => mg.Genre)
					.WithMany(g => g.MoviesGenres)
					.HasForeignKey(mg => mg.GenreId)
					.OnDelete(DeleteBehavior.Restrict),
					j => j
					.HasOne(mg => mg.Movie)
					.WithMany(m => m.MoviesGenres)
					.HasForeignKey(mg => mg.MoiveId)
					.OnDelete(DeleteBehavior.Cascade),
					j => j
					.HasKey(t => new { t.GenreId, t.MoiveId })
					);

		}

		private void TableConfigurations (EntityTypeBuilder<Movie> builder)
		{
			builder.Property(m => m.Name).IsRequired().HasMaxLength(250);
			builder.Property(m => m.Story).IsRequired().HasMaxLength(2500);
			builder.Property(m => m.Poster).IsRequired();
			builder.Property(m => m.Price).HasPrecision(10,2);
		}


	}
}

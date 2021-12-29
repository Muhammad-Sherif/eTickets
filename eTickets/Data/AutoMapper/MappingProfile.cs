using AutoMapper;
using eTickets.Data.ViewModels.Actors;
using eTickets.Data.ViewModels.Cinemas;
using eTickets.Data.ViewModels.Genres;
using eTickets.Data.ViewModels.Movies;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Genre, GenreViewModel>();
			CreateMap<GenreCreateViewModel, Genre>();
			CreateMap<Genre, GenreEditViewModel>().ReverseMap();


			CreateMap<Actor, ActorViewModel>();
			CreateMap<ActorCreateViewModel, Actor>().
				ForMember(
				dest => dest.Image, 
				options => options.MapFrom((src, dest) =>
				{
					using var dataStream = new MemoryStream();
					src.Image.CopyTo(dataStream);
					return dataStream.ToArray();
				}));


			
			CreateMap<Actor, ActorEditViewModel>();
			CreateMap<ActorEditViewModel, Actor>().
				ForMember(
				dest => dest.Image,
				options => options.MapFrom((src, dest) =>
				{
					if (src.ImageFile == null)
						return dest.Image;
					
					using var dataStream = new MemoryStream();
					src.ImageFile.CopyTo(dataStream);
					return dataStream.ToArray();
				}));




			CreateMap<Cinema, CinemaViewModel>();
			CreateMap<CinemaCreateViewModel, Cinema>().
				ForMember(
				dest => dest.Logo,
				options => options.MapFrom((src, dest) =>
				{
					using var dataStream = new MemoryStream();
					src.Logo.CopyTo(dataStream);
					return dataStream.ToArray();
				}));



			CreateMap<Cinema, CinemaEditViewModel>();
			CreateMap<CinemaEditViewModel, Cinema>().
				ForMember(
				dest => dest.Logo,
				options => options.MapFrom((src, dest) =>
				{
					if (src.LogoFile== null)
						return dest.Logo;

					using var dataStream = new MemoryStream();
					src.LogoFile.CopyTo(dataStream);
					return dataStream.ToArray();
				}));




			CreateMap<Movie, MovieViewModel>();

			CreateMap<MovieCreateViewModel, Movie>().
				ForMember(
				dest => dest.Poster,
				options => options.MapFrom((src, dest) =>
				{
					using var dataStream = new MemoryStream();
					src.Poster.CopyTo(dataStream);
					return dataStream.ToArray();
				})).
				ForMember(
				dest => dest.MoviesGenres,
				options => options.MapFrom((src, dest) =>
				{
					var moviesGenres = new List<MoviesGenres>();
					foreach (var id in src.GenresIds)
						moviesGenres.Add(new MoviesGenres { GenreId = id });

					return moviesGenres;
				})).
				ForMember(
				dest => dest.MoviesActors,
				options => options.MapFrom((src, dest) =>
				{
					var moviesActors = new List<MoviesActors>();
					foreach (var id in src.ActorsIds)
						moviesActors.Add(new MoviesActors { ActorId = id });

					return moviesActors;
				}));




			CreateMap<Movie, MovieEditViewModel>();

			CreateMap<MovieEditViewModel, Movie>().
				ForMember(
				dest => dest.Poster,
				options => options.MapFrom((src, dest) =>
				{
					if (src.PosterFile == null)
						return dest.Poster;

					using var dataStream = new MemoryStream();
					src.PosterFile.CopyTo(dataStream);
					return dataStream.ToArray();
				})).
				ForMember(
				dest => dest.MoviesGenres,
				options => options.MapFrom((src, dest) =>
				{
					var moviesGenres = new List<MoviesGenres>();
					foreach (var id in src.GenresIds)
						moviesGenres.Add(new MoviesGenres { GenreId = id });

					return moviesGenres;
				})).
				ForMember(
				dest => dest.MoviesActors,
				options => options.MapFrom((src, dest) =>
				{
					var moviesActors = new List<MoviesActors>();
					foreach (var id in src.ActorsIds)
						moviesActors.Add(new MoviesActors { ActorId = id });

					return moviesActors;
				}));








		}
	}
}

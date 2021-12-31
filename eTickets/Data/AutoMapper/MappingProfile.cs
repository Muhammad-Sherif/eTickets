using AutoMapper;
using eTickets.Data.Services.Implementation;
using eTickets.Data.Services.Interfaces;
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
		private readonly IFileServices _fileServices;
		public MappingProfile()
		{
			_fileServices = new FileServices(); // bad practice 

			GenreMapping();
			CinemaMapping();
			ActorMapping();
			MovieMapping();
			

		}
		private void GenreMapping()
		{
			CreateMap<Genre, GenreViewModel>();
			CreateMap<GenreCreateViewModel, Genre>();
			CreateMap<Genre, GenreEditViewModel>().ReverseMap();
		}
		private void ActorMapping()
		{

			CreateMap<Actor, ActorViewModel>();
			CreateMap<ActorCreateViewModel, Actor>().
				ForMember(
				dest => dest.Image,
				options => options.MapFrom(src => _fileServices.ConvertToByteArray(src.ImageFile)));


			CreateMap<Actor, ActorEditViewModel>();
			CreateMap<ActorEditViewModel, Actor>().
				ForMember(
				dest => dest.Image,
				options => options.MapFrom((src, dest) => src.ImageFile == null ? dest.Image : _fileServices.ConvertToByteArray(src.ImageFile)));

		}
		private void CinemaMapping()
		{
			CreateMap<Cinema, CinemaViewModel>();
			CreateMap<CinemaCreateViewModel, Cinema>().
				ForMember(
				dest => dest.Logo,
				options => options.MapFrom(src => _fileServices.ConvertToByteArray(src.LogoFile)));

			CreateMap<Cinema, CinemaEditViewModel>();
			CreateMap<CinemaEditViewModel, Cinema>().
				ForMember(
				dest => dest.Logo,
				options => options.MapFrom((src, dest) => src.LogoFile == null ? dest.Logo : _fileServices.ConvertToByteArray(src.LogoFile)));

		}
		private void MovieMapping()
		{


			CreateMap<Movie, MovieViewModel>();
			CreateMap<MovieCreateViewModel, Movie>()
				.ForMember(
				dest => dest.Poster,
				options => options.MapFrom((src, dest) => _fileServices.ConvertToByteArray(src.PosterFile)))
				.ForMember(
				dest => dest.MoviesGenres,
				options => options.MapFrom((src, dest) => src.GenresIds.Select(id => new MoviesGenres { GenreId = id, MoiveId = dest.Id }).ToList()))
				.ForMember(
				dest => dest.MoviesActors,
				options => options.MapFrom((src, dest) => src.ActorsIds.Select(id => new MoviesActors { ActorId = id, MoiveId = dest.Id }).ToList()));


			CreateMap<Movie, MovieEditViewModel>();
			CreateMap<MovieEditViewModel, Movie>()
				.ForMember(
				dest => dest.Poster,
				options => options.MapFrom((src, dest) => src.PosterFile == null ? dest.Poster : _fileServices.ConvertToByteArray(src.PosterFile)))
				.ForMember(
				dest => dest.MoviesGenres,
				options => options.MapFrom((src, dest) => src.GenresIds.Select(id => new MoviesGenres { GenreId = id, MoiveId = src.Id }).ToList()))
				.ForMember(
				dest => dest.MoviesActors,
				options => options.MapFrom((src, dest) => src.ActorsIds.Select(id => new MoviesActors { ActorId = id, MoiveId = src.Id }).ToList()));


		}
		
	}
}

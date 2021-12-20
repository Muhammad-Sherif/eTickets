using AutoMapper;
using eTickets.Data.ViewModels.Actors;
using eTickets.Data.ViewModels.Genres;
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




		}
	}
}

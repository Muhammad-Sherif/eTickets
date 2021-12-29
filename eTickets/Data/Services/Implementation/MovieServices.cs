using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.Services.Interfaces;
using eTickets.Data.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Implementation
{
	public class MovieServices : IMovieServices
	{
		private readonly IUnitOfWork _context;

		public MovieServices(IUnitOfWork context)
		{
			_context = context;
		}

		public async Task<MovieCreateViewModel> PopulateCreateFormDropListsAsync(MovieCreateViewModel MovieCreateViewModel)
		{
			var cinemas = await _context.Cinemas.GetAllAsync();
			var genres = await _context.Genres.GetAllAsync();
			var actors = await _context.Actors.GetAllAsync();
			MovieCreateViewModel.Cinemas= cinemas;
			MovieCreateViewModel.Genres = genres;
			MovieCreateViewModel.Actors = actors;
			return MovieCreateViewModel;

		}

		public async Task<MovieEditViewModel> PopulateEditFormDropListsAsync(MovieEditViewModel movieEditViewModel)
		{
			var cinemas = await _context.Cinemas.GetAllAsync();
			var genres = await _context.Genres.GetAllAsync();
			var actors = await _context.Actors.GetAllAsync();
			movieEditViewModel.Cinemas = cinemas;
			movieEditViewModel.Genres = genres;
			movieEditViewModel.Actors = actors;
			if(movieEditViewModel.ActorsIds == null)
				movieEditViewModel.ActorsIds = _context.MoviesActors.Find(ma=>ma.MoiveId == movieEditViewModel.Id).Select(ma=>ma.ActorId).ToList();
			if (movieEditViewModel.GenresIds == null)
				movieEditViewModel.GenresIds= _context.MoviesGenres.Find(mg=> mg.MoiveId == movieEditViewModel.Id).Select(mg=>mg.GenreId).ToList();


			return movieEditViewModel;

		}
	}
}

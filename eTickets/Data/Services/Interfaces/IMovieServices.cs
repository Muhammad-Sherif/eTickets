using eTickets.Data.ViewModels.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Interfaces
{
	public interface IMovieServices
	{
		Task<MovieCreateViewModel> PopulateCreateFormDropListsAsync(MovieCreateViewModel MovieCreateViewModel);
		Task<MovieEditViewModel> PopulateEditFormDropListsAsync(MovieEditViewModel movieEditViewModel);

	}
}

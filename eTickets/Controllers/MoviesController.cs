using AutoMapper;
using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.Services.Interfaces;
using eTickets.Data.ViewModels.Movies;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers

{
	[Authorize(Roles = nameof(UserRoles.Admin))]

	public class MoviesController : Controller
	{

		private readonly IUnitOfWork _context;
		private readonly IMovieServices _movieServices;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;

		public MoviesController(IUnitOfWork context, IMapper mapper, IToastNotification toastr , IMovieServices movieServices)
		{
			_context = context;
			_mapper = mapper;	
			_toastr = toastr;
			_movieServices = movieServices;
		}
		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			var movies = await _context.Movies.GetAllAsync(m => m.Cinema, m => m.Genres);
			var moviesViewModel = _mapper.Map<IEnumerable<MovieViewModel>>(movies);
			return View(moviesViewModel);
		}
		public async Task<IActionResult> Create()
		{
			return View(await _movieServices.PopulateCreateFormDropListsAsync(new MovieCreateViewModel())) ;
		}
		[HttpPost]
		public async Task<IActionResult> Create(MovieCreateViewModel movieCreateViewModel)
		{
			if (!ModelState.IsValid)
				return View(await _movieServices.PopulateCreateFormDropListsAsync(new MovieCreateViewModel()));


			var movie = _mapper.Map<Movie>(movieCreateViewModel);
			await _context.Movies.AddAsync(movie);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Movie created successfully");
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var movie = await _context.Movies.GetByIdAsync(id);
			

			if (movie == null)
				return View("NotFound");


			var movieEditViewModel = _mapper.Map<MovieEditViewModel>(movie);
			
			return View(await _movieServices.PopulateEditFormDropListsAsync(movieEditViewModel));

		}
		[HttpPost]
		public async Task<IActionResult> Edit(MovieEditViewModel movieEditViewModel)
		{
			var movie = await _context.Movies.FirstOrDefaultAsync(m=>m.Id == movieEditViewModel.Id , m=>m.MoviesActors , m => m.MoviesGenres);

			if (movie == null)
				return View("NotFound");

			if (!ModelState.IsValid)
			{
				movieEditViewModel.Poster = movie.Poster;
				return View(await _movieServices.PopulateEditFormDropListsAsync(movieEditViewModel));
			}
			movie = _mapper.Map(movieEditViewModel, movie);
			_context.Movies.Update(movie);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Movie edited successfully");
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var movie = await _context.Movies.GetByIdAsync(id);

			if (movie == null)
				return View("NotFound");

			_context.Movies.Delete(movie);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Movie Deleted successfully");
			return RedirectToAction(nameof(Index));
		}

	}
}

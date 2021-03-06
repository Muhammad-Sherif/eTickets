using AutoMapper;
using eTickets.Data.Enums;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.ViewModels.Genres;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	[Authorize(Roles = nameof(UserRoles.Admin))]
	public class GenresController : Controller
	{
		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;
		public GenresController(IUnitOfWork context , IMapper mapper, IToastNotification toastr)
		{
			_context = context;
			_mapper = mapper;
			_toastr = toastr;
		}
		public async Task<IActionResult> Index()
		{
			var genresViewModel = _mapper.Map<IEnumerable<GenreViewModel>>(await _context.Genres.GetAllAsync());
			return View(genresViewModel);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(GenreCreateViewModel  genreCreateViewModel)
		{
			if(!ModelState.IsValid)
				return View(genreCreateViewModel);


			var genre = _mapper.Map<Genre>(genreCreateViewModel);
			await _context.Genres.AddAsync(genre);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Genre created successfully");
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var genre = await _context.Genres.GetByIdAsync(id);

			if(genre == null)
				return View("NotFound");

			var genreEditViewModel = _mapper.Map<GenreEditViewModel>(genre);
			return View(genreEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(GenreEditViewModel genreEditViewModel)
		{
			if (!ModelState.IsValid)
				return View(genreEditViewModel);

			var genre = await _context.Genres.GetByIdAsync(genreEditViewModel.Id);

			if(genre == null)
				return View("NotFound");

			genre = _mapper.Map(genreEditViewModel, genre);
			_context.Genres.Update(genre);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Genre edited successfully");
			return RedirectToAction(nameof(Index));

		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var genre = await _context.Genres.GetByIdAsync(id);

			if (genre == null)
				return View("NotFound");

			_context.Genres.Delete(genre);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Genre Deleted successfully");
			return RedirectToAction(nameof(Index));

		}
	}
}

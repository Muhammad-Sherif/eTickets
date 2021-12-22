using AutoMapper;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.ViewModels.Cinemas;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	public class CinemasController : Controller
	{

		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;

		public CinemasController(IUnitOfWork context, IMapper mapper, IToastNotification toastr)
		{
			_context = context;
			_mapper = mapper;
			_toastr = toastr;
		}

		public async Task<IActionResult> Index()
		{
			var cinemas = await _context.Cinemas.GetAllAsync();
			var cinemasViewModel = _mapper.Map<IEnumerable<CinemaViewModel>>(cinemas);
			return View(cinemasViewModel);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CinemaCreateViewModel cinemaCreateViewModel)
		{
			if (!ModelState.IsValid)
				return View(cinemaCreateViewModel);


			var cinema = _mapper.Map<Cinema>(cinemaCreateViewModel);
			await _context.Cinemas.AddAsync(cinema);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Cinema created successfully");
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var cinema = await _context.Cinemas.GetByIdAsync(id);

			if (cinema == null)
				return View("NotFound");

			var cinemaEditViewModel = _mapper.Map<CinemaEditViewModel>(cinema);
			return View(cinemaEditViewModel);

		}
		[HttpPost]
		public async Task<IActionResult> Edit(CinemaEditViewModel cinemaEditViewModel)
		{	
			var cinema = await _context.Cinemas.GetByIdAsync(cinemaEditViewModel.Id);

			if (cinema == null)
				return View("NotFound");

			if (!ModelState.IsValid)
			{
				cinemaEditViewModel.Logo = cinema.Logo;
				return View(cinemaEditViewModel);
			}


			cinema = _mapper.Map(cinemaEditViewModel, cinema);
			_context.Cinemas.Update(cinema);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Cinema edited successfully");
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var cinema = await _context.Cinemas.GetByIdAsync(id);

			if (cinema == null)
				return View("NotFound");

			_context.Cinemas.Delete(cinema);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Cinema Deleted successfully");
			return RedirectToAction(nameof(Index));
		}

	}
}

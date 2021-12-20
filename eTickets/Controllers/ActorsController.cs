using AutoMapper;
using eTickets.Data;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.ViewModels.Actors;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	public class ActorsController : Controller
	{

		private readonly IUnitOfWork _context;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastr;

		public ActorsController(IUnitOfWork context, IMapper mapper, IToastNotification toastr)
		{
			_context = context;
			_mapper = mapper;
			_toastr = toastr;
		}

		public async Task<IActionResult> Index()
		{
			var actors = await _context.Actors.GetAllAsync();
			var actorsViewModel = _mapper.Map<IEnumerable<ActorViewModel>>(actors);
			return View(actorsViewModel);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(ActorCreateViewModel actorCreateViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(actorCreateViewModel);
			}
			var actor = _mapper.Map<Actor>(actorCreateViewModel);
			await _context.Actors.AddAsync(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor created successfully");
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			
			var actor = await _context.Actors.GetByIdAsync(id);
			if(actor == null)
			{
				_toastr.AddErrorToastMessage("No actor found with this id");
				return RedirectToAction(nameof(Index));
			}
			var actorEditViewModel = _mapper.Map<ActorEditViewModel>(actor);
			return View(actorEditViewModel);

		}
		[HttpPost]
		public async Task<IActionResult> Edit(ActorEditViewModel actorEditViewModel)
		{
			if(!ModelState.IsValid)
			{
				return View(actorEditViewModel);
			}

			var actor = await _context.Actors.GetByIdAsync(actorEditViewModel.Id);

			if (actor == null)
			{
				_toastr.AddErrorToastMessage("No actor found with this id");
				return RedirectToAction(nameof(Index));
			}

			actor = _mapper.Map(actorEditViewModel, actor);
			_context.Actors.Update(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor edited successfully");
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int id)
		{

			var actor = await _context.Actors.GetByIdAsync(id);

			if (actor == null)
			{
				_toastr.AddErrorToastMessage("No actor found with this id");
				return RedirectToAction(nameof(Index));
			}
			_context.Actors.Delete(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor Deleted successfully");
			return RedirectToAction(nameof(Index));
		}

	}
}

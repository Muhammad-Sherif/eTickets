using AutoMapper;
using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Repositories.Interfaces;
using eTickets.Data.ViewModels.Actors;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
	[Authorize(Roles = nameof(UserRoles.Admin))]
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
				return View(actorCreateViewModel);


			var actor = _mapper.Map<Actor>(actorCreateViewModel);
			await _context.Actors.AddAsync(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor created successfully");
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if(id == null)
				return View("BadRequest");

			var actor = await _context.Actors.GetByIdAsync(id);

			if(actor == null)
				return View("NotFound");

			var actorEditViewModel = _mapper.Map<ActorEditViewModel>(actor);
			return View(actorEditViewModel);

		}
		[HttpPost]
		public async Task<IActionResult> Edit(ActorEditViewModel actorEditViewModel)
		{
			var actor = await _context.Actors.GetByIdAsync(actorEditViewModel.Id);

			if (actor == null)
				return View("NotFound");

			if (!ModelState.IsValid)
			{
				actorEditViewModel.Image = actor.Image;
				return View(actorEditViewModel);
			}


			actor = _mapper.Map(actorEditViewModel, actor);
			_context.Actors.Update(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor edited successfully");
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return View("BadRequest");

			var actor = await _context.Actors.GetByIdAsync(id);

			if (actor == null)
				return View("NotFound");

			_context.Actors.Delete(actor);
			_context.SaveChanges();
			_toastr.AddSuccessToastMessage("Actor Deleted successfully");
			return RedirectToAction(nameof(Index));
		}

	}
}

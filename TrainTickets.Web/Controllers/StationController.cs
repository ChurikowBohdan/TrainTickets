using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTickets.Routes;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Web.Controllers {
	public class StationController : TrainTicketsControllerBase {

		private readonly IRouteService _routeService;

		public StationController(IRouteService routeService) {
			_routeService = routeService;
		}

		[HttpGet]
		public ActionResult List() {
			return View(_routeService.GetStations());
		}

		[HttpGet]
		public ActionResult Delete(int id) {
			_routeService.DeleteStation(id);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Edit(int id) {
			var station = _routeService.GetStation(id);
			return View(station);
		}

		[HttpPost]
		public ActionResult Edit(StationDto station) {
			if (!ModelState.IsValid) {
				return RedirectToAction("Edit", new { Id = station.Id });
			}

			_routeService.UpdateStation(station);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Add() {
			return View();
		}

		[HttpPost]
		public ActionResult Add(StationDto newStation) {
			if (ModelState.IsValid) {
				_routeService.AddStation(newStation);
			}
			return RedirectToAction("List");
		}
	}
}
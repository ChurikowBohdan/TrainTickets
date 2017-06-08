using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTickets.Routes;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Web.Controllers {
	public class RouteController : TrainTicketsControllerBase {
		private readonly IRouteService _routeService;

		public RouteController(
			IRouteService routeService
		) {
			_routeService = routeService;
		}

		[HttpGet]
		public ActionResult List() {
			var listItems = _routeService.GetRoutes();
			return View(listItems);
		}

		[HttpGet]
		public ActionResult Details(int trainId) {
			var detailsDto = _routeService.GetRouteDetails(trainId);
			return View(detailsDto);
		}

		[HttpGet]
		public ActionResult Delete(int trainId) {
			_routeService.DeleteRoute(trainId);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Add() {
			var addRouteDetails = _routeService.GetAddRouteDetails();
			return View(addRouteDetails);
		}

		[HttpPost]
		public ActionResult Add(AddRouteDto addRouteDto) {
			_routeService.AddRout(addRouteDto);
			return RedirectToAction("List");
		}


	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTickets.Routes;

namespace TrainTickets.Web.Controllers {
	public class RouteController : TrainTicketsControllerBase {
		private readonly IRouteService _routeService;

		public RouteController(
			IRouteService routeService
		) {
			_routeService = routeService;
		}

		public ActionResult List() {
			var listItems = _routeService.GetRoutes();
			return View(listItems);
		}
	}
}
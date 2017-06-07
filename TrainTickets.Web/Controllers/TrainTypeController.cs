using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTickets.Trains;
using TrainTickets.Trains.Dto;


namespace TrainTickets.Web.Controllers {
	public class TrainTypeController : TrainTicketsControllerBase {

		private readonly ITrainService _trainService;

		public TrainTypeController(ITrainService trainService) {
			_trainService = trainService;
		}

		[HttpGet]
		public ActionResult List() {
			return View(_trainService.GetTrainTypes());
		}

		[HttpGet]
		public ActionResult Delete(int id) {
			_trainService.DeleteTrainType(id);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Edit(int id) {
			var trainType = _trainService.GetTrainType(id);
			return View(trainType);
		}

		[HttpPost]
		public ActionResult Edit(TrainTypeDto trainType) {
			if (!ModelState.IsValid) {
				return RedirectToAction("Edit", new { Id = trainType.Id });
			}

			_trainService.UpdateTrainType(trainType);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Add() {
			return View();
		}

		[HttpPost]
		public ActionResult Add(TrainTypeDto trainType) {
			if (ModelState.IsValid) {
				_trainService.UpdateTrainType(trainType);
			}

			return RedirectToAction("List");
		}
	}
}
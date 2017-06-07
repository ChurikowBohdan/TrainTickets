using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainTickets.Trains;
using TrainTickets.Trains.Dto;

namespace TrainTickets.Web.Controllers {
	public class TrainController : TrainTicketsControllerBase {

		private readonly ITrainService _trainService;
		public TrainController(ITrainService trainService) {
			_trainService = trainService;
		}

		[HttpGet]
		public ActionResult List() {
			var trainsDto = _trainService.GetTrains();
			return View(trainsDto);
		}

		[HttpGet]
		public ActionResult Edit(int id) {
			var train = _trainService.GetTrain(id);
			return View(train);
		}

		[HttpPost]
		public ActionResult Edit(TrainDto trainDto) {
			_trainService.UpdateTrain(trainDto);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Delete(int id) {
			_trainService.DeleteTrain(id);
			return RedirectToAction("List");
		}

		[HttpGet]
		public ActionResult Add() {
			var trainDto = new TrainDto {
				AvailableTrainTypes = _trainService.GetTrainTypes()
			};
			return View(trainDto);
		}

		[HttpPost]
		public ActionResult Add(TrainDto trainDto) {
			_trainService.AddTrain(trainDto);
			return RedirectToAction("List");
		}
	}
}
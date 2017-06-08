using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes.Dto;
using TrainTickets.Trains;

namespace TrainTickets.Routes {
	public class RouteService : ApplicationService, IRouteService {

		private readonly IRepository<Station> _stationsRepository;
		private readonly IRepository<Route> _routeRepository;
		private readonly IRepository<Train> _trainRepository;
		private readonly ITrainService _trainService;

		public RouteService(
			IRepository<Station> stationsRepository,
			IRepository<Route> routeRepository,
			IRepository<Train> trainRepository,
			ITrainService trainService
		) {
			_stationsRepository = stationsRepository;
			_routeRepository = routeRepository;
			_trainRepository = trainRepository;
			_trainService = trainService; 
		}

		public void AddRout(AddRouteDto routeDto) {
			int nextNumber = _routeRepository.GetAll().Max(t => t.Number) + 1;
			var orderedRoutes = routeDto.RouteParts.OrderBy(t => t.Order).ToList();
			var firstRoutePart = orderedRoutes.First();
			var prevRoute = _routeRepository.Insert(new Route {
				DispatchingStationId = firstRoutePart.DisaptchingStationId,
				ArrivalStationId = firstRoutePart.ArrivalStationId,
				Price = firstRoutePart.Price,
				DepartureTime = firstRoutePart.DisaptchingTime,
				ArrivalTime = firstRoutePart.ArrivalTime,
				TrainId = routeDto.TrainId,
				PreviousRouteId = null,
				Number = nextNumber
			});

			foreach (var routePart in orderedRoutes.Skip(1)) {
				prevRoute = _routeRepository.Insert(new Route {
					DispatchingStationId = routePart.DisaptchingStationId,
					ArrivalStationId = routePart.ArrivalStationId,
					Price = routePart.Price,
					DepartureTime = routePart.DisaptchingTime,
					ArrivalTime = routePart.ArrivalTime,
					TrainId = routeDto.TrainId,
					PreviousRoute = prevRoute,
					Number =nextNumber
				});
			}
		}

		public void AddStation(StationDto stationDto) {
			var station = stationDto.MapTo<Station>();
			_stationsRepository.Insert(station);
		}

		public void DeleteRoute(int trainId) {
			_routeRepository.Delete(t => t.TrainId == trainId);
		}

		public void DeleteStation(int id) {
			_stationsRepository.Delete(id);
		}

		public AddRouteDto GetAddRouteDetails() {
			var addRouteDetails = new AddRouteDto();
			addRouteDetails.AvailableStations = GetStations().ToList();
			addRouteDetails.AvailableTrains = _trainService.GetTrains();
			addRouteDetails.RouteParts = new List<AddRoutePartDto>();
			addRouteDetails.ArrivalTime = DateTime.Now;
			addRouteDetails.DisaptchingTime = DateTime.Now;
			return addRouteDetails;
		}

		public RouteDetailsDto GetRouteDetails(int number) {
			var trainRoute = _routeRepository.GetAll().Where(t => t.Number == number).ToList();
			if (trainRoute == null) {
				return null;
			}

			RouteDetailsDto detailsDto = new RouteDetailsDto();
			var train = _trainRepository.Get(trainRoute.First().TrainId);
			detailsDto.TrainId = train.Id;
			detailsDto.TrainNumber = train.Number;
			detailsDto.TotalPlaces = train.PlacesCount;
			detailsDto.AvailablePlaces = train.PlacesCount; //TODO obezhan: change after added oreder logic.
			detailsDto.TotalPrice = trainRoute.Sum(t => t.Price);
			detailsDto.DisaptchingStation = trainRoute.Single(t => t.PreviousRouteId == null)?.DisaptchingStation?.Name;
			detailsDto.DisaptchingTime = trainRoute.Single(t => t.PreviousRouteId == null).DepartureTime;
			var lastRoutePart = trainRoute.OrderBy(t => t.ArrivalTime).Last();
			detailsDto.ArrivalStation = lastRoutePart.ArrivalStation.Name;
			detailsDto.ArrivalTime = lastRoutePart.ArrivalTime;

			detailsDto.ChildRoutes = new List<RouteListItemDto>();
			foreach (var routePart in trainRoute) {
				var childRoute = new RouteListItemDto();
				childRoute.DisaptchingStation = routePart.DisaptchingStation.Name;
				childRoute.DisaptchingTime = routePart.DepartureTime;
				childRoute.ArrivalStation = routePart.ArrivalStation.Name;
				childRoute.ArrivalTime = routePart.ArrivalTime;
				childRoute.Id = routePart.Id;
				childRoute.Price = routePart.Price;
				detailsDto.ChildRoutes.Add(childRoute);
			}
			return detailsDto;
		}

		public ICollection<RouteListItemDto> GetRoutes() {
			ICollection<RouteListItemDto> resultList = new List<RouteListItemDto>();
			var routes = _routeRepository.GetAll();
			var groupedRoutes = routes.GroupBy(t => t.Number).ToList();
			foreach (var trainRoute in groupedRoutes) {
				var routeListItem = new RouteListItemDto();
				routeListItem.TrainNumber = _trainRepository.Get(trainRoute.First().TrainId).Number;
				routeListItem.DisaptchingStation = trainRoute.First(t => t.PreviousRouteId == null).DisaptchingStation?.Name;
				routeListItem.DisaptchingTime = trainRoute.First(t => t.PreviousRouteId == null).DepartureTime;
				routeListItem.Price = trainRoute.Sum(t => t.Price);
				var lastRoute = trainRoute.OrderBy(t => t.DepartureTime).Last();
				routeListItem.ArrivalStation = lastRoute.ArrivalStation.Name;
				routeListItem.ArrivalTime = lastRoute.ArrivalTime;
				routeListItem.TrainId = lastRoute.TrainId;
				routeListItem.Number = lastRoute.Number;
				resultList.Add(routeListItem);
			}

			return resultList;
		}

		public StationDto GetStation(int id) {
			return _stationsRepository.Get(id).MapTo<StationDto>();
		}

		public ICollection<StationDto> GetStations() {
			return _stationsRepository.GetAll().MapTo<ICollection<StationDto>>();
		}

		public void UpdateStation(StationDto stationDto) {
			var station = new Station {
				Id = stationDto.Id,
				Name = stationDto.Name
			};
			_stationsRepository.Update(station);
		}
	}
}

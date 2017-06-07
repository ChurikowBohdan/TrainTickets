using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Routes {
	public class RouteService : ApplicationService, IRouteService {

		private readonly IRepository<Station> _stationsRepository;
		private readonly IRepository<Route> _routeRepository;
		private readonly IRepository<Train> _trainRepository;

		public RouteService(
			IRepository<Station> stationsRepository,
			IRepository<Route> routeRepository,
			IRepository<Train> trainRepository
		) {
			_stationsRepository = stationsRepository;
			_routeRepository = routeRepository;
			_trainRepository = trainRepository;
		}

		public void AddStation(StationDto stationDto) {
			var station = stationDto.MapTo<Station>();
			_stationsRepository.Insert(station);
		}

		public void DeleteStation(int id) {
			_stationsRepository.Delete(id);
		}

		public ICollection<RouteListItemDto> GetRoutes() {
			ICollection<RouteListItemDto> resultList = new List<RouteListItemDto>();
			var routes = _routeRepository.GetAll();
			var groupedRoutes = routes.GroupBy(t => t.TrainId).ToList();
			foreach (var trainRoute in groupedRoutes) {
				var routeListItem = new RouteListItemDto();
				routeListItem.TrainNumber = _trainRepository.Get(trainRoute.Key).Number;
				routeListItem.DisaptchingStation = trainRoute.First(t => t.PreviousStationId == null).DisaptchingStation?.Name;
				routeListItem.ArrivalStation = trainRoute.First(t => t.NextStationId == null).ArrivalStation?.Name;
				routeListItem.DisaptchingTime = trainRoute.First(t => t.PreviousStationId == null).DepartureTime;
				routeListItem.ArrivalTime = trainRoute.First(t => t.NextStationId == null).ArrivalTime;
				routeListItem.Price = trainRoute.Sum(t => t.Price);
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

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

		public RouteService(
			IRepository<Station> stationsRepository
		) {
			_stationsRepository = stationsRepository;
		}

		public void AddStation(StationDto stationDto) {
			var station = stationDto.MapTo<Station>();
			_stationsRepository.Insert(station);
		}

		public void DeleteStation(int id) {
			_stationsRepository.Delete(id);
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

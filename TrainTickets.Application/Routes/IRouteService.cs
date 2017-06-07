using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Routes {
	public interface IRouteService : IApplicationService {

		//Stations
		ICollection<StationDto> GetStations();
		StationDto GetStation(int id);
		void DeleteStation(int id);
		void UpdateStation(StationDto station);
		void AddStation(StationDto station);

		//Routes
		ICollection<RouteListItemDto> GetRoutes();

	}
}

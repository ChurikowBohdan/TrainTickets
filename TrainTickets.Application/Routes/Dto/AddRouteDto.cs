using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Trains.Dto;

namespace TrainTickets.Routes.Dto {
	public class AddRouteDto : EntityDto {

		public IList<StationDto> AvailableStations { get; set; }

		public ICollection<TrainDto> AvailableTrains { get; set; }
		public int TrainId { get; set; }

		public ICollection<AddRoutePartDto> RouteParts { get; set; }

		public int DisaptchingStationId { get; set; }
		public int ArrivalStationId { get; set; }
		public DateTime DisaptchingTime { get; set; }
		public DateTime ArrivalTime { get; set; }


	}
}

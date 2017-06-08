using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Orders.Dto {
	public class FindPageDto {
		public IList<StationDto> AvailableStations { get; set; }
		public int DisaptchingStationId { get; set; }
		public int ArrivalStationId { get; set; }
		public DateTime FromDate { get; set; }
	}
}

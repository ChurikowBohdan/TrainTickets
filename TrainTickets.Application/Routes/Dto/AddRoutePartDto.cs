using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes.Dto {
	public class AddRoutePartDto {

		public int DisaptchingStationId { get; set; }
		public int ArrivalStationId { get; set; }
		public DateTime DisaptchingTime { get; set; }
		public DateTime ArrivalTime { get; set; }
		public decimal Price { get; set; }
		public int Order { get; set; }
	}
}

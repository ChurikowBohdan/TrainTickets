using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets {
	public class Route : Entity<int> {
		public int DispatchingStationId { get; set; }
		public int ArrivalStationId { get; set; }
		public int? PreviousRouteId { get; set; }
		public decimal Price { get; set; }
		public DateTime DepartureTime { get; set; }
		public DateTime ArrivalTime { get; set; }
		public int TrainId { get; set; }
		public int Number { get; set; }

		public virtual Station DisaptchingStation { get; set; }
		public virtual Station ArrivalStation { get; set; }
		public virtual Route PreviousRoute { get; set; }
		public virtual Train Train { get; set; }
	}
}

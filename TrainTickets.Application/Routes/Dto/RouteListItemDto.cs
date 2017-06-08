using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes.Dto {
	public class RouteListItemDto : EntityDto {

		public string DisaptchingStation { get; set; }
		public DateTime DisaptchingTime { get; set; }

		public string ArrivalStation { get; set; }
		public DateTime ArrivalTime { get; set; }
		public decimal Price { get; set; }
		public string TrainNumber { get; set; }
		public int TrainId { get; set; }
		public int Number { get; set; }
	}
}

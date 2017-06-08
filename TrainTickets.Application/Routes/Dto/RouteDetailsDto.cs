using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes.Dto {

	[AutoMapFrom(typeof(Route))]
	[AutoMapTo(typeof(Route))]
	public class RouteDetailsDto : EntityDto {

		public int TrainId { get; set; }
		public string TrainNumber { get; set; }
		public decimal TotalPrice { get; set; }
		public int TotalPlaces { get; set; }
		public int AvailablePlaces { get; set; }
		public DateTime ArrivalTime { get; set; }
		public string ArrivalStation { get; set; }
		public DateTime DisaptchingTime { get; set; }
		public string DisaptchingStation { get; set; }

		public ICollection<RouteListItemDto> ChildRoutes { get; set; }
	}
}

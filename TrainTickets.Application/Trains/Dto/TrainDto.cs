using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Trains.Dto {

	[AutoMapFrom(typeof(Train))]
	[AutoMapTo(typeof(Train))]
	public class TrainDto : EntityDto {
		public string Number { get; set; }
		public int PlacesCount { get; set; }
		public string TrainTypeName { get; set; }
		public ICollection<TrainTypeDto> AvailableTrainTypes { get; set; }
		public int TrainTypeId { get; set; }
	}
}

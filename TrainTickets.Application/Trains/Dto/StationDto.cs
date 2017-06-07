using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Trains.Dto {

	[AutoMapFrom(typeof(TrainType))]
	[AutoMapTo(typeof(TrainType))]
	public class TrainTypeDto : EntityDto {
		public string Name { get; set; }
	}
}

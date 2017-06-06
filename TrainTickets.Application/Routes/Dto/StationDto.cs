using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes.Dto {

	[AutoMapFrom(typeof(Station))]
	public class StationDto : EntityDto {
		public string Name { get; set; }
	}
}

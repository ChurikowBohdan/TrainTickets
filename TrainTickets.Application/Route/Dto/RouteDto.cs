using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Routes.Dto
{
    [AutoMapFrom(typeof (Route))]
    public class RouteDto: EntityDto
    {
       public string Start { get; set; }
       public string End { get; set; }
       
    }
}

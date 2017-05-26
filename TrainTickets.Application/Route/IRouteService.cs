using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Routes.Dto;

namespace TrainTickets.Route
{
    public interface IRouteService : IApplicationService
    {
        ListResultDto<RouteDto> GetListItems();
    }
}

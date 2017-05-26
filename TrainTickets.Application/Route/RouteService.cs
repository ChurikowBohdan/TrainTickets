using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

using Abp.Domain.Repositories;
using TrainTickets.Route;
using TrainTickets.Routes.Dto;
using Abp.AutoMapper;

namespace TrainTickets.Routes
{
    public class RouteService : TrainTicketsAppServiceBase, IRouteService
    {
        private readonly IRepository<Route> _routeRepository;
        public RouteService (IRepository<Route> routeRepository) {
            _routeRepository = routeRepository;
        }
        public ListResultDto<RouteDto> GetListItems()
        {
            var routes = _routeRepository
                .GetAll().ToList();

            
            var routesDto = routes.MapTo<List<RouteDto>>();
            return new ListResultDto<RouteDto>(routesDto);
          
            
        }
    }
}

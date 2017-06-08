using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Orders.Dto;

namespace TrainTickets.Orders {
	public interface IOrderService : IApplicationService {

		//List
		IList<OrderListItemDto> GetOrderListItemsDto();
		OrderDetailsDto GetOrderDetails(int orderId);

		//Create
		FindPageDto GetFindPageViewModel();
		AvailableRoutItemsDto FindAvailableRoutes(FindPageDto findResults);
		CreateOrderPageDto GetOrderPageViewModel(int routeNumber);
		Order CreateOrder(OrderDto orderDto);
		OrderConfirmationResult GetOrderConfirmationResult(int orderId);
	}
}

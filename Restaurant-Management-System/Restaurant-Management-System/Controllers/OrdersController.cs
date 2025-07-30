using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_System.Application.UseCase.Orders;
using Restaurant_Management_System.Application.UseCase.Orders.Dtos;
using Restaurant_Management_System.Application.UseCase.Orders.Parameters;
using Restaurant_Management_System.Domain.Entities.Enum;
using static Restaurant_Management_System.Application.Common.Constants;
using Route = Restaurant_Management_System.Application.Common.Constants.OrderRoutes;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrdersController : BaseController
    {
        private readonly IOrderManagement _orderManagement;

        public OrdersController(IOrderManagement orderManagement)
        {
            _orderManagement = orderManagement;
        }

        [HttpPost(Route.AddNewOrder)]
        public async Task<IActionResult> AddNewOrder([FromBody] CreateOrderDto dto)
        {
            var response = await _orderManagement.CreateOrderAsync(dto);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Route.SalesReport)]
        public async Task<IActionResult> GetSalesReport([FromQuery] SalesReportQueryParameters parameters)
        {
            var response = await _orderManagement.GetSalesReportAsync(parameters);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Route.Orders)]
        public async Task<IActionResult> GetOrders([FromQuery] OrderQueryParameters parameters)
        {
            var response = await _orderManagement.GetAllOrdersAsync(parameters);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(Route.Order)]
        public async Task<IActionResult> GetOrder([FromQuery] int id)
        {
            var response = await _orderManagement.GetOrderByIdAsync(id);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(Route.Remove)]
        public async Task<IActionResult> RemoveOrder([FromRoute] int id)
        {
            var response = await _orderManagement.RemoveOrder(id);
            return Result(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(Route.UpdateStatus)]
        public async Task<IActionResult> UpdateOrderStatus(
            [FromRoute] int orderId,
            [FromQuery] enOrderStatus status)
        {
            var response = await _orderManagement.UpdateOrderStatus(orderId, status);
            return Result(response);
        }

    }
}

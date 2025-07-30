using Event_Registration_System.Application.Common;
using Restaurant_Management_System.Application.UseCase.Orders.Dtos;
using Restaurant_Management_System.Application.UseCase.Orders.Parameters;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Orders
{
    public interface IOrderManagement
    {
        Task<ApiResponse> CreateOrderAsync(CreateOrderDto dto);
        Task<ApiResponse> GetOrderByIdAsync(int id);
        Task<ApiResponse> GetAllOrdersAsync(OrderQueryParameters parameters);
        Task<ApiResponse> RemoveOrder(int id);
        Task<ApiResponse> UpdateOrderStatus(int orderId, enOrderStatus status);
        Task<ApiResponse> GetSalesReportAsync(SalesReportQueryParameters parameters);
    }
}

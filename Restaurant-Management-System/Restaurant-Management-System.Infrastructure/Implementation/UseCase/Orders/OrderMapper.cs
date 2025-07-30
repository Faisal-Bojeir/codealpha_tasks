using Restaurant_Management_System.Application.UseCase.OrderItems.Dtos;
using Restaurant_Management_System.Application.UseCase.Orders.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Orders
{
    public static class OrderMapper
    {
        public static OrderItem MapTo(this CreateOrderItemDto dto, decimal unitPrice)
        {
            return new()
            {
                MenuItemId = dto.MenuItemId,
                Quantity = dto.Quantity,
                UnitPrice = unitPrice,
                TotalPrice = dto.Quantity * unitPrice
            };
        }

        public static Order MapTo(this CreateOrderDto dto)
        {
            return new()
            {
                OrderDate = DateTime.Now,
                Status = Domain.Entities.Enum.enOrderStatus.New,
            };
        }

        public static OrderDto MapTo(this Order order)
        {
            return new()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,                
            };
        }
    }
}

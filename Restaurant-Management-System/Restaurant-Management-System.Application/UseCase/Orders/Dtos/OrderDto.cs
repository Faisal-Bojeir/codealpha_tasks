using Restaurant_Management_System.Application.UseCase.OrderItems.Dtos;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public enOrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}

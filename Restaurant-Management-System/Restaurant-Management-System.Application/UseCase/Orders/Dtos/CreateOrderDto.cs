using Restaurant_Management_System.Application.UseCase.OrderItems.Dtos;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Orders.Dtos
{
    public class CreateOrderDto
    {
        public required List<CreateOrderItemDto> OrderItems { get; set; }
    }
}

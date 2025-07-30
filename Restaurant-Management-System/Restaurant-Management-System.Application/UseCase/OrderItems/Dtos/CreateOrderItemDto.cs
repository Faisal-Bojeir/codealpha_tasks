using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.OrderItems.Dtos
{
    public class CreateOrderItemDto
    {
        public required int MenuItemId { get; set; }
        public required int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos
{
    public class UpdateInventoryItemDto
    {
        public required string Name { get; set; }
        public required double Quantity { get; set; }
    }
}

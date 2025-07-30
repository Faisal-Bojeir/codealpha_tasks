using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos
{
    public class InventoryItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.MenuItemInventories.Dtos
{
    public class MenuItemInventoryDto
    {
        public int InventoryItemId { get; set; }
        public string InventoryItemName { get; set; }
        public double QuantityUsed { get; set; }
    }
}

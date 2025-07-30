using Event_Registration_System.Domain.Contract;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Domain.Entities.JoinEntities
{
    public class MenuItemInventory : ISoftDelete
    {
        public int Id { get; set; }
        public required int MenuItemId { get; set; }
        public required int InventoryItemId { get; set; }
        public required double QuantityUsed { get; set; }
        public MenuItem MenuItem { get; set; }
        public InventoryItem InventoryItem { get; set; }
        public bool IsDeleted { get; set; }
    }

}

using Event_Registration_System.Domain.Contract;
using Restaurant_Management_System.Domain.Entities.Enum;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Domain.Entities.Domains
{
    public class MenuItem : ISoftDelete
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required bool IsAvailable { get; set; } = true;
        public required enMenuCategory Category { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<MenuItemInventory> MenuItemInventories { get; set; }
        public bool IsDeleted { get; set; }
    }

}

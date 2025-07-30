using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Domain.Entities.JoinEntities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required int MenuItemId { get; set; }
        public required int Quantity { get; set; }
        public required decimal UnitPrice { get; set; }
        public required decimal TotalPrice { get; set; }
        public Order Order { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}

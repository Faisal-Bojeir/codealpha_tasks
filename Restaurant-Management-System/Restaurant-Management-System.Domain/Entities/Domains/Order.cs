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
    public class Order : ISoftDelete
    {
        public int Id { get; set; }
        public required DateTime OrderDate { get; set; } = DateTime.Now;
        public required enOrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public bool IsDeleted { get; set; }
    }
}

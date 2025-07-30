using Event_Registration_System.Domain.Contract;
using Event_Registration_System.Domain.Entities.Domains;
using Event_Registration_System.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Entities.JoinEntities
{
    public class UserEvents : ISoftDelete
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

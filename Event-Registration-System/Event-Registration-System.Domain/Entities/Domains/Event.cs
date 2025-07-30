using Event_Registration_System.Domain.Contract;
using Event_Registration_System.Domain.Entities.JoinEntities;
using Event_Registration_System.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Entities.Domains
{
    public class Event : ISoftDelete
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required DateTime StartDate { get; set; } = DateTime.Now;
        public required DateTime EndDate { get; set; }
        public int SeatsAvailable { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<UserEvents> UserEvents { get; set; } = new List<UserEvents>();
    }
}

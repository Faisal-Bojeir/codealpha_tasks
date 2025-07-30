using Event_Registration_System.Domain.Contract;
using Event_Registration_System.Domain.Entities.Enum;
using Event_Registration_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Entities.Users
{
    public class User : ISoftDelete
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required enRole Role { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<UserEvents> UserEvents { get; set; } = new List<UserEvents>();
    }
}

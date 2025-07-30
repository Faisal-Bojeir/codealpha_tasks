using Event_Registration_System.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}

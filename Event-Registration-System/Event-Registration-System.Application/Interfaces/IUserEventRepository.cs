using Event_Registration_System.Domain.Entities.JoinEntities;
using Event_Registration_System.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.Interfaces
{
    public interface IUserEventRepository : IBaseRepository<UserEvents>
    {
    }
}

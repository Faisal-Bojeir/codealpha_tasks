using Event_Registration_System.Application.Interfaces;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Domain.Entities.JoinEntities;
using Event_Registration_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.Repository
{
    public class UserEventRepository : BaseRepository<UserEvents>, IUserEventRepository
    {
        public UserEventRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using Event_Registration_System.Application.Interfaces;
using Event_Registration_System.Domain.Entities.Domains;
using Event_Registration_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }
    }
}

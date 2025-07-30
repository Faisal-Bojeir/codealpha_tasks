using Event_Registration_System.Application.UseCase.Event.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.Event
{
    public static class EventMapper
    {
        public static Event_Registration_System.Domain.Entities.Domains.Event MapTo(this CreateEventDto dto)
        {
            return new()
            {
                Title = dto.Title,
                Description = dto.Description,
                EndDate = dto.EndDate,
                Location = dto.Location,
                StartDate = dto.StartDate,
                SeatsAvailable = dto.SeatsAvailable,
            };
        }
    }
}

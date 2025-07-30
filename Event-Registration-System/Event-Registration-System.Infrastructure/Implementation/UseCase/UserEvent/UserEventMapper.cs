using Event_Registration_System.Application.UseCase.UserEvent.Dtos;
using eve = Event_Registration_System.Domain.Entities.Domains;
using Event_Registration_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.UserEvent
{
    public static class UserEventMapper
    {
        public static GetUserEventsDto GetMyEvents(this eve.Event eventa, DateTime registerDate)
        {
            return new()
            {
                Title = eventa.Title,
                Description = eventa.Description,
                StartDate = eventa.StartDate,
                EndDate = eventa.EndDate,
                Location = eventa.Location,
                RegisterDate = registerDate,
                SeatsAvailable = eventa.SeatsAvailable,
                EventId = eventa.Id
            };
        }

        public static GetEventsDto GetEvents(this eve.Event eventa)
        {
            return new()
            {
                Title = eventa.Title,
                Description = eventa.Description,
                StartDate = eventa.StartDate,
                EndDate = eventa.EndDate,
                Location = eventa.Location,
                SeatsAvailable = eventa.SeatsAvailable,
                EventId = eventa.Id
            };
        }

        public static UserEvents MapTo(int eventId, int userId)
        {
            return new()
            {
                UserId = userId,
                EventId = eventId,
                RegisterDate = DateTime.Now
            };
        }
    }
}

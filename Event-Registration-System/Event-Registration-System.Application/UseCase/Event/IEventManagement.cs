using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.UseCase.Event.Dtos;
using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Event
{
    public interface IEventManagement
    {
        Task<ApiResponse> GetActiveEvents(QueryStringParameters parameters);
        Task<ApiResponse> GetAllEvents(QueryStringParameters parameters);
        Task<ApiResponse> AddNewEvent(CreateEventDto dto);
        Task<ApiResponse> RemoveEvent(int id);
    }
}

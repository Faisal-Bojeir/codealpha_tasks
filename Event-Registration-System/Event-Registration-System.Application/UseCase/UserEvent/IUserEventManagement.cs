using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Event
{
    public interface IUserEventManagement
    {
        Task<ApiResponse> JoinToEventAsync(int eventId, int userId);
        Task<ApiResponse> CancelJoinAsync(int eventId, int userId);
        Task<ApiResponse> GetAllEvents(int userId, QueryStringParameters parameters);
        Task<ApiResponse> GetMyEvents(int userId, QueryStringParameters parameters);
    }
}

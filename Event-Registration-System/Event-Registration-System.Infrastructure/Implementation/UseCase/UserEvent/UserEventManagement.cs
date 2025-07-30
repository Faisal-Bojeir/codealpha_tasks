using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.Interfaces;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Application.UseCase.UserEvent.Dtos;
using Event_Registration_System.Domain.Entities.JoinEntities;
using Event_Registration_System.Domain.Entities.Users;
using Event_Registration_System.Domain.Helper;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Event_Registration_System.Infrastructure.Implementation.UseCase.UserEvent;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using eve = Event_Registration_System.Domain.Entities.Domains;

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.Event
{
    public class UserEventManagement : IUserEventManagement
    {
        private readonly IUserEventRepository _userEventRepository;
        private readonly IEventRepository _eventRepository;

        public UserEventManagement(IUserEventRepository userEventRepository, IEventRepository eventRepository)
        {
            _userEventRepository = userEventRepository;
            _eventRepository = eventRepository;
        }
        public async Task<ApiResponse> CancelJoinAsync(int eventId, int userId)
        {
            var eventaUser = await _userEventRepository.GetByConditionAsync(ue => ue.EventId == eventId && ue.UserId == userId && ue.IsDeleted == false);
            if (eventaUser == null)
            {
                return ApiResponse.Fail("You are not join in this event");
            }
            SoftDelete.Delete(eventaUser);
            await _userEventRepository.UpdateAsync(eventaUser);
            return ApiResponse.Success(data: null);
        }

        public async Task<ApiResponse> GetAllEvents(int userId, QueryStringParameters parameters)
        {
            Expression<Func<eve.Event, bool>> condition = x =>
                !x.IsDeleted &&
                !x.UserEvents.Any(ue => ue.UserId == userId && !ue.IsDeleted);
            var events = await _eventRepository.GetRangeByConditionAsync(
                condition,
                parameters,
                includes: e => e.UserEvents
            );
            var result = events.Map(s => s.GetEvents());
            return ApiResponse.Success(result);
        }

        public async Task<ApiResponse> GetMyEvents(int userId, QueryStringParameters parameters)
        {
            Expression<Func<UserEvents, bool>> condition = ue => ue.IsDeleted == false && ue.UserId == userId;
            var userEvents = await _userEventRepository.GetRangeByConditionAsync(
                condition,
                parameters,
                includes: ue => ue.Event
            );
            var result = userEvents.Map(s => s.Event.GetMyEvents(s.RegisterDate));
            return ApiResponse.Success(data: null);
        }

        public async Task<ApiResponse> JoinToEventAsync(int eventId, int userId)
        {
            var eventaUser = await _userEventRepository.GetByConditionAsync(ue => ue.EventId == eventId && ue.UserId == userId && ue.IsDeleted);
            if (eventaUser != null)
            {
                if (eventaUser.IsDeleted == true)
                {
                    eventaUser.IsDeleted = false;
                    eventaUser.RegisterDate = DateTime.Now;
                    await _userEventRepository.UpdateAsync(eventaUser);
                    return ApiResponse.Create(null);
                }
                return ApiResponse.Fail("You are already join in this event");
            }
            var userEvent = UserEventMapper.MapTo(eventId, userId);
            await _userEventRepository.CreateAsync(userEvent);
            return ApiResponse.Create(null);
        }
    }
}

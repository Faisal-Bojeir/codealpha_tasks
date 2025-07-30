using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.Interfaces;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Application.UseCase.Event.Dtos;
using eve = Event_Registration_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Event_Registration_System.Domain.Helper;

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.Event
{
    public class EventManagement : IEventManagement
    {
        private readonly IEventRepository _eventRepository;

        public EventManagement(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<ApiResponse> AddNewEvent(CreateEventDto dto)
        {
            if (dto.EndDate <= DateTime.Now)
            {
                return ApiResponse.Fail("End date must be in the future.");
            }

            if (dto.EndDate <= dto.StartDate)
            {
                return ApiResponse.Fail("End date must be after start date.");
            }

            if (dto.SeatsAvailable <= 0)
            {
                return ApiResponse.Fail("Seats must be up than 0.");
            }

            var eventa = dto.MapTo();

            await _eventRepository.CreateAsync(eventa);
            return ApiResponse.Create();
        }

        public async Task<ApiResponse> GetActiveEvents(QueryStringParameters parameters)
        {
            Expression<Func<eve.Event, bool>> condition = x => x.EndDate < DateTime.Now && x.IsDeleted == false;
            var result = await _eventRepository.GetRangeByConditionAsync(condition, parameters);
            return ApiResponse.Success(result);
        }

        public async Task<ApiResponse> GetAllEvents(QueryStringParameters parameters)
        {
            Expression<Func<eve.Event, bool>> condition = x => x.IsDeleted == false;
            var result = await _eventRepository.GetRangeByConditionAsync(condition, parameters);
            return ApiResponse.Success(result);
        }

        public async Task<ApiResponse> RemoveEvent(int id)
        {
            var eventa = await _eventRepository.GetByIdAsync(id);
            if (eventa is null)
            {
                return ApiResponse.Fail("No Event found to delete.");
            }
            SoftDelete.Delete(eventa);
            await _eventRepository.UpdateAsync(eventa);
            return ApiResponse.Success(null);
        }
    }
}

using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Application.UseCase.Event.Dtos;
using Event_Registration_System.Domain.Entities.Enum;
using Event_Registration_System.Domain.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using r = Event_Registration_System.Application.Common.Constants.AdminRoutes;

namespace Event_Registration_System.Controllers
{
    [Authorize(Roles = nameof(enRole.Admin))]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : BaseController
    {
        private readonly IEventManagement _eventManagement;

        public AdminController(IEventManagement eventManagement)
        {
            _eventManagement = eventManagement;
        }

        [HttpPost(r.AddEvent)]
        public async Task<IActionResult> AddNewEvent([FromBody] CreateEventDto dto)
        {
            var result = await _eventManagement.AddNewEvent(dto);
            return Result(result);
        }

        [HttpGet(r.GetEvents)]
        public async Task<IActionResult> GetEvents([FromQuery] QueryStringParameters parameters)
        {
            var result = await _eventManagement.GetAllEvents(parameters);
            return Result(result);
        }

        [HttpGet(r.GetActiveEvents)]
        public async Task<IActionResult> GetActiveEvents([FromQuery] QueryStringParameters parameters)
        {
            var result = await _eventManagement.GetActiveEvents(parameters);
            return Result(result);
        }

        [HttpDelete(r.RemoveEvent)]
        public async Task<IActionResult> RemoveEvents([FromRoute] int eventId)
        {
            var result = await _eventManagement.RemoveEvent(eventId);
            return Result(result);
        }
    }

}

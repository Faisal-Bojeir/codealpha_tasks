using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Domain.Entities.Enum;
using Event_Registration_System.Domain.Helper;
using Event_Registration_System.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Routes = Event_Registration_System.Application.Common.Constants.UserRoutes;

namespace Event_Registration_System.Controllers
{
    [Authorize(Roles = nameof(enRole.User))]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserEventManagement _userEventManagement;

        public UserController(IUserEventManagement userEventManagement)
        {
            _userEventManagement = userEventManagement;
        }

        [HttpPost(Routes.JoinToEvent)]
        public async Task<IActionResult> JoinToEvent(int eventId)
        {
            var userId = User.GetUserId();
            var result = await _userEventManagement.JoinToEventAsync(eventId, userId!.Value);
            return Result(result);
        }

        [HttpPost(Routes.CancelJoin)]
        public async Task<IActionResult> CancelJoin(int eventId)
        {
            var userId = User.GetUserId();
            var result = await _userEventManagement.CancelJoinAsync(eventId, userId!.Value);
            return Result(result);
        }

        [HttpGet(Routes.GetAllEvents)]
        public async Task<IActionResult> GetAllEvents([FromQuery] QueryStringParameters parameters)
        {
            var userId = User.GetUserId();
            var result = await _userEventManagement.GetAllEvents(userId!.Value, parameters);
            return Result(result);
        }

        [HttpGet(Routes.GetMyEvents)]
        public async Task<IActionResult> GetMyEvents([FromQuery] QueryStringParameters parameters)
        {
            var userId = User.GetUserId();
            var result = await _userEventManagement.GetMyEvents(userId!.Value, parameters);
            return Result(result);
        }
    }
}

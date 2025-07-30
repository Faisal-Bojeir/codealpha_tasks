using Event_Registration_System.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Management_System.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Result(ApiResponse response)
        {
            return response.StatudCode switch
            {
                200 => Ok(response),
                201 => Created(string.Empty, response),
                400 => BadRequest(response),
                401 => Unauthorized(response),
                404 => NotFound(response),
                409 => Conflict(response),
                _ => StatusCode(response.StatudCode >= 500 ? 500 : response.StatudCode, response),
            };
        }
    }
}

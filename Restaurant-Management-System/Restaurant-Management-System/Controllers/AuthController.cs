using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Application.UseCase.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;
using Route = Restaurant_Management_System.Application.Common.Constants.AuthRoutes;

namespace Restaurant_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuth _auth;

        public AuthenticationController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost(Route.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _auth.Login(dto);
            return Result(result);
        }
    }
}

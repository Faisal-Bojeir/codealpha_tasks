using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Application.UseCase.Auth.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using auth = Event_Registration_System.Application.Common.Constants.AuthRoutes;

namespace Event_Registration_System.Controllers
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

        [HttpPost(auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _auth.Login(dto);
            return Result(result);
        }

        [HttpPost(auth.SignUp)]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto dto)
        {
            var result = await _auth.SignUp(dto);
            return Result(result);
        }
    }
}

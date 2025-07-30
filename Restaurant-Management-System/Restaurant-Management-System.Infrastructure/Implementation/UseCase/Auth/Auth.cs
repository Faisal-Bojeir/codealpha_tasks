using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Application.UseCase.Auth.Dtos;
using Event_Registration_System.Domain.Entities.Users;
using Event_Registration_System.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Auth
{
    public class Auth : IAuth
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public Auth(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByConditionAsync(u => u.Username == dto.Username && u.Password == dto.Password);
            if (user is null)
            {
                return ApiResponse.Unauthorized("Invalid Info.");
            }

            string token = _tokenService.GenerateToken(user);
            return ApiResponse.Success(token, "Login Successful.");
        }
    }
}

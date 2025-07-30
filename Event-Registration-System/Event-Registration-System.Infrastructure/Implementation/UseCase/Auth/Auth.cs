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

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.Auth
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
            return ApiResponse.Success("Login Successful.", token);
        }

        public async Task<ApiResponse> SignUp(SignUpDto dto)
        {
            var isUsernameExist = await _userRepository.GetByConditionAsync(u => u.Username.ToLower() == dto.Username.ToLower());

            if (isUsernameExist is not null)
            {
                return ApiResponse.Confilct("Username already exist.");
            }

            var user = dto.ToUser();
            await _userRepository.CreateAsync(user);
            return ApiResponse.Create("User created successfully.");
        }
    }
}

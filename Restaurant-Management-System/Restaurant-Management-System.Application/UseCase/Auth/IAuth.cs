using Event_Registration_System.Application.Common;
using Event_Registration_System.Application.UseCase.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Auth
{
    public interface IAuth
    {
        Task<ApiResponse> Login(LoginDto dto);
    }
}

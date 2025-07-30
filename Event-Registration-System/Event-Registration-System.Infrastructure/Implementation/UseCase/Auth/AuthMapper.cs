using Event_Registration_System.Application.UseCase.Auth.Dtos;
using Event_Registration_System.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure.Implementation.UseCase.Auth
{
    public static class AuthMapper
    {
        public static User ToUser(this SignUpDto dto)
        {
            return new()
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                Password = dto.Password,
                Username = dto.Username,
                Role = Domain.Entities.Enum.enRole.User
            };
        }
    }
}

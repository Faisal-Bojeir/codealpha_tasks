using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Auth.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username is Required.")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public required string Password { get; set; }
    }
}

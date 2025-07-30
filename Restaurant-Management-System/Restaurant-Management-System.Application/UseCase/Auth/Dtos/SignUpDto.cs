using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.UseCase.Auth.Dtos
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "First Name Required.")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Middle Name Required.")]
        public required string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name Required.")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Username Required.")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Password Name Required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "Password must be at least 8 characters and contain a lowercase, uppercase, and number.")]
        public required string Password { get; set; }
    }
}

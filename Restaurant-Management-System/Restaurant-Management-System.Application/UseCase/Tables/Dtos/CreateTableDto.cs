using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Tables.Dtos
{
    public class CreateTableDto
    {
        public required string Number { get; set; }
        public required int Seats { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}

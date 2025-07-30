using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Tables.Dtos
{
    public class TableAvailabilityDto
    {
        public int Seats { get; set; }
        public bool IsAvailable { get; set; }
    }
}

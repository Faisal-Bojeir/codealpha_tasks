using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Reservations.Dtos
{
    public class UpdateReservationInfoDto
    {
        public int? TableId { get; set; }
        public enReservationStatus Status { get; set; }
    }
}

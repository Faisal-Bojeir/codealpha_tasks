using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Reservations.Dtos
{
    public class CreateReservationDto
    {
        public required int TableId { get; set; }
        public required string CustomerName { get; set; }
        public required DateTime ReservationTime { get; set; }
        public required int NumberOfGuests { get; set; }
    }
}

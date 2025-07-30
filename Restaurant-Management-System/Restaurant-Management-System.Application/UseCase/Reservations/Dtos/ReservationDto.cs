using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Reservations.Dtos
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public enReservationStatus Status { get; set; }
    }

}

using Event_Registration_System.Domain.Helper;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Reservations.Parameters
{
    public class ReservationQueryParameters : QueryStringParameters
    {
        public int? TableId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public enReservationStatus? Status { get; set; }
        public int? MinGuests { get; set; }
        public int? MaxGuests { get; set; }
    }
}

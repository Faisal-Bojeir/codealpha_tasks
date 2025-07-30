using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Domain.Entities.Domains
{
    public class Reservation
    {
        public int Id { get; set; }
        public required int TableId { get; set; }
        public required string CustomerName { get; set; }
        public required DateTime ReservationTime { get; set; }
        public required int NumberOfGuests { get; set; }
        public required enReservationStatus Status { get; set; }

        public Table Table { get; set; }
    }
}

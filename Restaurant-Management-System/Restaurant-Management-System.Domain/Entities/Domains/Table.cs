using Event_Registration_System.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Domain.Entities.Domains
{
    public class Table : ISoftDelete
    {
        public int Id { get; set; }
        public required string Number { get; set; }
        public required int Seats { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

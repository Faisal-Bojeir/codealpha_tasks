using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Tables.Parameters
{
    public class TableQueryParameters : QueryStringParameters
    {
        public string? Number { get; set; }
        public int? MinSeats { get; set; }
        public int? MaxSeats { get; set; }
        public bool? IsAvailable { get; set; }
    }
}

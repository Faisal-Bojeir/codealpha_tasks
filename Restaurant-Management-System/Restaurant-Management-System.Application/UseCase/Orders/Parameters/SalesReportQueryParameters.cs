using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Orders.Parameters
{
    public class SalesReportQueryParameters : QueryStringParameters
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}

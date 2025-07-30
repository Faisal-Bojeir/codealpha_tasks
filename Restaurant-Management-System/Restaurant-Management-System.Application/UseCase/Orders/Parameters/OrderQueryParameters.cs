using Event_Registration_System.Domain.Helper;
using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Orders.Parameters
{
    public class OrderQueryParameters : QueryStringParameters
    {
        public enOrderStatus? Status { get; set; }
    }
}

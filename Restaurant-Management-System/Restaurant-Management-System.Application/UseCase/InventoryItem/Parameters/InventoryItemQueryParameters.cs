using Event_Registration_System.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.InventoryItem.Parameters
{
    public class InventoryItemQueryParameters : QueryStringParameters
    {
        public string? Name { get; set; }
        public double? MinQuantity { get; set; }
        public double? MaxQuantity { get; set; }
    }

}

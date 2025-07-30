using Event_Registration_System.Domain.Interfaces;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.Interfaces
{
    public interface IInventoryItemRepository : IBaseRepository<InventoryItem>
    {        
        Task<Dictionary<int, double>> GetQuantitiesMap(List<int> inventoryItemIds);
        Task DecreaseQuantityAsync(InventoryItem item, double quantity);
    }
}

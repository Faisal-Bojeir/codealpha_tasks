using Event_Registration_System.Domain.Interfaces;
using Restaurant_Management_System.Infrastructure.Data;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.Repository
{
    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        private readonly AppDbContext _context;
        public InventoryItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Dictionary<int, double>> GetQuantitiesMap(List<int> inventoryItemIds)
        {
            return await _context.InventoryItems
                .Where(i => inventoryItemIds.Contains(i.Id))
                .ToDictionaryAsync(i => i.Id, i => i.Quantity);
        }

        public async Task DecreaseQuantityAsync(InventoryItem item, double quantity)
        {
            item.Quantity -= quantity;
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}

using Restaurant_Management_System.Infrastructure.Data;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.Repository
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        private readonly AppDbContext _context;
        public MenuItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetPrice(int id)
        {
            var price = await _context.MenuItems
                .Where(o => o.Id == id)
                .Select(o => o.Price)
                .FirstOrDefaultAsync();

            return price;
        }
    }
}

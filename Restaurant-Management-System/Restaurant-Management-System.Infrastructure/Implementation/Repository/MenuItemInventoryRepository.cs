using Restaurant_Management_System.Infrastructure.Data;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.Repository
{
    public class MenuItemInventoryRepository : BaseRepository<MenuItemInventory>, IMenuItemInventoryRepository
    {
        public MenuItemInventoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}

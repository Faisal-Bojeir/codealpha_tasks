using Restaurant_Management_System.Application.UseCase.MenuItemInventories.Dtos;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItemInventories
{
    public static class MenuItemInventoryMapper
    {
        public static MenuItemInventoryDto MapTo(this MenuItemInventory entity)
        {
            return new MenuItemInventoryDto
            {
                InventoryItemId = entity.InventoryItemId,
                InventoryItemName = entity.InventoryItem.Name,
                QuantityUsed = entity.QuantityUsed
            };
        }

        public static MenuItemInventory MapTo(this CreateMenuItemInventoryDto dto)
        {
            return new MenuItemInventory
            {
                MenuItemId = dto.MenuItemId,
                InventoryItemId = dto.InventoryItemId,
                QuantityUsed = dto.QuantityUsed
            };
        }
    }
}

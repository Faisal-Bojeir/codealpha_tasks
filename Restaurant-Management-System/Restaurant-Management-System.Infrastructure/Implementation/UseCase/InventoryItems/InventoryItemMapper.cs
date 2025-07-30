using m = Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.InventoryItems
{
    public static class InventoryItemMapper
    {
        public static m.InventoryItem MapTo(this CreateInventoryItemDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
            };
        }

        public static m.InventoryItem MapTo(this UpdateInventoryItemDto dto, int id)
        {
            return new()
            {
                Id = id,
                Name = dto.Name,
                Quantity = dto.Quantity,
            };
        }
    }
}

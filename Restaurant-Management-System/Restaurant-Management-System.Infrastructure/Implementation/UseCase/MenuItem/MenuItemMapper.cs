using m = Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Management_System.Application.UseCase.MenuItem.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItem
{
    public static class MenuItemMapper
    {
        public static m.MenuItem MapTo(this CreateMenuItemDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Category = dto.Category,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
            };
        }

        public static m.MenuItem MapTo(this UpdateMenuItemDto dto)
        {
            return new()
            {
                Name = dto.Name,
                Category = dto.Category,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
            };
        }

        public static MenuItemDto MapTo(this m.MenuItem menuItem)
        {
            return new()
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Category = menuItem.Category,
                ImageUrl = menuItem.ImageUrl,
                IsAvailable = menuItem.IsAvailable,
                Price = menuItem.Price
            };
        }
    }
}

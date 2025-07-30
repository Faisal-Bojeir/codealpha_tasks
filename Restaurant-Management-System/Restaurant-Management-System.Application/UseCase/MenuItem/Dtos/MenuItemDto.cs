using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.MenuItem.Dtos
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public enMenuCategory Category { get; set; }
        public bool IsAvailable { get; set; }
        public string? ImageUrl { get; set; }
    }
}

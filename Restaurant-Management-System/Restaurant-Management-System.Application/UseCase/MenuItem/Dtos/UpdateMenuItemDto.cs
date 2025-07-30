using Restaurant_Management_System.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.MenuItem.Dtos
{
    public class UpdateMenuItemDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required enMenuCategory Category { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? ImageUrl { get; set; }
    }

}

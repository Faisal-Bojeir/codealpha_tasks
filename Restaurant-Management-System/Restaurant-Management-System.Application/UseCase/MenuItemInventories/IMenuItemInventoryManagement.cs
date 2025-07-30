using Event_Registration_System.Application.Common;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.MenuItemInventories
{
    public interface IMenuItemInventoryManagement
    {
        Task<ApiResponse> AddMenuItemInventory(CreateMenuItemInventoryDto dto);
        Task<ApiResponse> UpdateMenuItemInventory(int id, UpdateMenuItemInventoryDto dto);
        Task<ApiResponse> DeleteMenuItemInventory(int id);
        Task<ApiResponse> GetByMenuItemId(int menuItemId, MenuItemInventoryQueryParameter parameter);
    }
}

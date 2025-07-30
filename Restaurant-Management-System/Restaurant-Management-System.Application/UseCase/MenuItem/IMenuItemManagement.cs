using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Restaurant_Management_System.Application.UseCase.MenuItem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.MenuItem
{
    public interface IMenuItemManagement
    {
        Task<ApiResponse> GetMenus(MenuItemQueryParameters parameters);
        Task<ApiResponse> GetMenuById(int id);
        Task<ApiResponse> CreateMenuItem(CreateMenuItemDto dto);
        Task<ApiResponse> UpdateMenuItem(UpdateMenuItemDto dto);
        Task<ApiResponse> DeleteMenuItem(int id);
    }

}

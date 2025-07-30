using Event_Registration_System.Application.Common;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.InventoryItem
{
    public interface IInventoryItemManagement
    {
        Task<ApiResponse> AddNewInventoryItem(CreateInventoryItemDto dto);
        Task<ApiResponse> GetInventoryItems(InventoryItemQueryParameters parameters);
        Task<ApiResponse> UpdateInventoryItem(int id, UpdateInventoryItemDto dto);
        Task<ApiResponse> DeleteInventoryItem(int id);
    }
}

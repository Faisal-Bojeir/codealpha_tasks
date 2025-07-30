using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Domain.Entities.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItemInventories
{
    public class MenuItemInventoryManagement : IMenuItemInventoryManagement
    {
        private readonly IMenuItemInventoryRepository _repository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public MenuItemInventoryManagement(
            IMenuItemInventoryRepository repository,
            IMenuItemRepository menuItemRepository,
            IInventoryItemRepository inventoryItemRepository)
        {
            _repository = repository;
            _menuItemRepository = menuItemRepository;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task<ApiResponse> AddMenuItemInventory(CreateMenuItemInventoryDto dto)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(dto.MenuItemId);
            if (menuItem is null)
                return ApiResponse.Fail("Menu item not found");

            var inventoryItem = await _inventoryItemRepository.GetByIdAsync(dto.InventoryItemId);
            if (inventoryItem is null)
                return ApiResponse.Fail("Inventory item not found");

            if (dto.QuantityUsed <= 0)
                return ApiResponse.Fail("Quantity used must be greater than 0");

            var entity = dto.MapTo();
            await _repository.CreateAsync(entity);
            return ApiResponse.Create();
        }

        public async Task<ApiResponse> UpdateMenuItemInventory(int id, UpdateMenuItemInventoryDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Not found.");

            if (dto.QuantityUsed <= 0)
                return ApiResponse.Fail("Quantity used must be greater than 0");

            entity.QuantityUsed = dto.QuantityUsed;
            await _repository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> DeleteMenuItemInventory(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Not found");

            SoftDelete.Delete(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetByMenuItemId(int menuItemId, MenuItemInventoryQueryParameter parameter)
        {
            Expression<Func<MenuItemInventory, bool>> condition = x => x.MenuItemId == menuItemId;
            var menuItems = await _repository.GetRangeByConditionAsync(condition, parameter, default, i => i.InventoryItem);
            var response = menuItems.Map(o => o.MapTo());
            return ApiResponse.Success(response);
        }
    }
}

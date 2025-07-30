using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.MenuItem;
using Restaurant_Management_System.Application.UseCase.MenuItem.Dtos;
using m = Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LinqKit;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItem
{
    public class MenuItemManagement : IMenuItemManagement
    {
        private readonly IMenuItemRepository _repository;
        
        public MenuItemManagement(IMenuItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse> CreateMenuItem(CreateMenuItemDto dto)
        {
            if (dto.Price <= 0)
                return ApiResponse.Fail("Price can not be 0 or negitive");

            var entity = dto.MapTo();
            await _repository.CreateAsync(entity);
            return ApiResponse.Create();
        }

        public async Task<ApiResponse> DeleteMenuItem(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Item not found.");

            SoftDelete.Delete(entity);
            await _repository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetMenuById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Item not found.");

            var dto = entity.MapTo();
            return ApiResponse.Success(dto);
        }

        public async Task<ApiResponse> GetMenus(MenuItemQueryParameters parameters)
        {
            Expression<Func<m.MenuItem, bool>> condition = m => true;

            if (parameters.Category.HasValue)
                condition = condition.And(m => m.Category == parameters.Category.Value);

            if (parameters.MinPrice.HasValue)
                condition = condition.And(m => m.Price >= parameters.MinPrice.Value);

            if (parameters.MaxPrice.HasValue)
                condition = condition.And(m => m.Price <= parameters.MaxPrice.Value);

            if (parameters.IsAvailable.HasValue)
                condition = condition.And(m => m.IsAvailable == parameters.IsAvailable.Value);

            var query = await _repository.GetRangeByConditionAsync(condition, parameters);
            return ApiResponse.Success(query);
        }

        public async Task<ApiResponse> UpdateMenuItem(UpdateMenuItemDto dto)
        {
            if (dto.Price <= 0)
                return ApiResponse.Fail("Price can not be 0 or negitive");

            var entity = dto.MapTo();
            await _repository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }
    }
}

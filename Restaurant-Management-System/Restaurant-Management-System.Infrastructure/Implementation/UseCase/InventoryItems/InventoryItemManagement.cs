using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.InventoryItem;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Dtos;
using Restaurant_Management_System.Application.UseCase.InventoryItem.Parameters;
using m = Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.InventoryItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.InventoryItem
{
    public class InventoryItemManagement : IInventoryItemManagement
    {
        private readonly IInventoryItemRepository _repository;
        public InventoryItemManagement(IInventoryItemRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse> AddNewInventoryItem(CreateInventoryItemDto dto)
        {
            if (dto.Quantity < 0)
            {
                return ApiResponse.Fail("Quantity can't be negitive.");
            }

            var entity = dto.MapTo();
            await _repository.CreateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> DeleteInventoryItem(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Not Found.");

            SoftDelete.Delete(entity);
            await _repository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetInventoryItems(InventoryItemQueryParameters parameters)
        {
            Expression<Func<m.InventoryItem, bool>> condition = m => true;

            if (!string.IsNullOrEmpty(parameters.Name))
                condition = condition.And(m => m.Name == parameters.Name);

            if (parameters.MinQuantity.HasValue)
                condition = condition.And(m => m.Quantity >= parameters.MinQuantity.Value);

            if (parameters.MaxQuantity.HasValue)
                condition = condition.And(m => m.Quantity >= parameters.MaxQuantity.Value);

            var query = await _repository.GetRangeByConditionAsync(condition, parameters);
            return ApiResponse.Success(query);
        }

        public async Task<ApiResponse> UpdateInventoryItem(int id, UpdateInventoryItemDto dto)
        {
            if (dto.Quantity < 0)
            {
                return ApiResponse.Fail("Quantity can't be negitive.");
            }

            var entity = dto.MapTo(id);
            await _repository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }
    }
}

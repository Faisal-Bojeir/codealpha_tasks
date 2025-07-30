using Event_Registration_System.Application.Common;
using Event_Registration_System.Domain.Helper;
using LinqKit;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Tables;
using Restaurant_Management_System.Application.UseCase.Tables.Dtos;
using Restaurant_Management_System.Application.UseCase.Tables.Parameters;
using Restaurant_Management_System.Domain.Entities.Domains;
using System.Linq.Expressions;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Tables
{
    public class TableManagement : ITableManagement
    {
        private readonly ITableRepository _tableRepository;

        public TableManagement(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<ApiResponse> AddNewTable(CreateTableDto dto)
        {
            if (dto.Seats < 0)
                dto.Seats = 0;

            var entity = dto.MapTo();
            await _tableRepository.CreateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> GetTables(TableQueryParameters parameters)
        {
            Expression<Func<Table, bool>> condition = r => true;

            if (!string.IsNullOrWhiteSpace(parameters.Number))
                condition = condition.And(r => r.Number.ToLower().StartsWith(parameters.Number.ToLower()));

            if (parameters.MaxSeats.HasValue)
                condition = condition.And(r => r.Seats <= parameters.MaxSeats);

            if (parameters.MinSeats.HasValue)
                condition = condition.And(r => r.Seats >= parameters.MinSeats);

            if (parameters.IsAvailable.HasValue)
                condition = condition.And(r => r.IsAvailable == parameters.IsAvailable);

            var query = await _tableRepository.GetRangeByConditionAsync(
                condition,
                parameters,
                cancellationToken: default
            );

            return ApiResponse.Success(query);
        }

        public async Task<ApiResponse> RemoveTable(int id)
        {
            var entity = await _tableRepository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Not Found.");

            SoftDelete.Delete(entity);
            await _tableRepository.UpdateAsync(entity);
            return ApiResponse.Success(null);
        }

        public async Task<ApiResponse> UpdateTable(int id, UpdateTableDto dto)
        {
            var entity = await _tableRepository.GetByIdAsync(id);
            if (entity is null)
                return ApiResponse.Fail("Not Found.");

            var table = dto.MapTo(id);
            await _tableRepository.UpdateAsync(table);
            return ApiResponse.Success(null);
        }
    }
}

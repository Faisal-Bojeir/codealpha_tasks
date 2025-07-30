using Event_Registration_System.Application.Common;
using Restaurant_Management_System.Application.UseCase.Tables.Dtos;
using Restaurant_Management_System.Application.UseCase.Tables.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Application.UseCase.Tables
{
    public interface ITableManagement
    {
        Task<ApiResponse> AddNewTable(CreateTableDto dto);
        Task<ApiResponse> UpdateTable(int id, UpdateTableDto dto);
        Task<ApiResponse> GetTables(TableQueryParameters parameters);
        Task<ApiResponse> RemoveTable(int id);
    }
}

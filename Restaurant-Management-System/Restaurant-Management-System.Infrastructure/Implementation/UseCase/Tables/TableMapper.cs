using Restaurant_Management_System.Application.UseCase.Tables.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.UseCase.Tables
{
    public static class TableMapper
    {
        public static Table MapTo(this CreateTableDto dto)
        {
            return new()
            {
                Number = dto.Number,
                Seats = dto.Seats,
                IsAvailable = dto.IsAvailable,
            };
        }

        public static Table MapTo(this UpdateTableDto dto, int id)
        {
            return new()
            {
                Id = id,
                Number = dto.Number ?? "No name for this.",
                Seats = dto.Seats < 0 ? 0 : dto.Seats ?? 0
            };
        }
    }
}

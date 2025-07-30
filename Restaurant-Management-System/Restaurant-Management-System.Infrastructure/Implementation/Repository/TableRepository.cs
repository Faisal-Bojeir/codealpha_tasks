using Restaurant_Management_System.Infrastructure.Data;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Tables.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.Repository
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        private readonly AppDbContext _context;
        public TableRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<TableAvailabilityDto?> GetTableAvailabilityAsync(int tableId)
        {
            return await _context.Tables
                .Where(t => t.Id == tableId)
                .Select(t => new TableAvailabilityDto
                {
                    IsAvailable = t.IsAvailable,
                    Seats = t.Seats
                })
                .FirstOrDefaultAsync();
        }
    }
}

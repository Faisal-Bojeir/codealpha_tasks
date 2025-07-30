using Event_Registration_System.Infrastructure.Implementation.Repository;
using Microsoft.EntityFrameworkCore;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.Orders.Dtos;
using Restaurant_Management_System.Domain.Entities.Domains;
using Restaurant_Management_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure.Implementation.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

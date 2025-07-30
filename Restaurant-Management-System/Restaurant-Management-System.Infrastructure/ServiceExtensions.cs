using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Domain.Interfaces;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Event_Registration_System.Infrastructure.Implementation.UseCase.Auth;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Management_System.Application.Interfaces;
using Restaurant_Management_System.Application.UseCase.InventoryItem;
using Restaurant_Management_System.Application.UseCase.MenuItem;
using Restaurant_Management_System.Application.UseCase.MenuItemInventories;
using Restaurant_Management_System.Application.UseCase.Orders;
using Restaurant_Management_System.Application.UseCase.Reservations;
using Restaurant_Management_System.Application.UseCase.Tables;
using Restaurant_Management_System.Infrastructure.Implementation.Repository;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.Auth;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.InventoryItem;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItem;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.MenuItemInventories;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.Orders;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.Reservations;
using Restaurant_Management_System.Infrastructure.Implementation.UseCase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepositroy, OrderItemRepositroy>();
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            services.AddScoped<IMenuItemInventoryRepository, MenuItemInventoryRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAuth, Auth>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IInventoryItemManagement, InventoryItemManagement>();
            services.AddScoped<IMenuItemManagement, MenuItemManagement>();
            services.AddScoped<IMenuItemInventoryManagement, MenuItemInventoryManagement>();
            services.AddScoped<IOrderManagement, OrderManagement>();
            services.AddScoped<IReservationManagement, ReservationManagement>();
            services.AddScoped<ITableManagement, TableManagement>();

            return services;
        }
    }
}

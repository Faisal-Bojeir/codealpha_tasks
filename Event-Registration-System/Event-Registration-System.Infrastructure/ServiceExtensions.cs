using Event_Registration_System.Application.Interfaces;
using Event_Registration_System.Application.UseCase.Auth;
using Event_Registration_System.Application.UseCase.Event;
using Event_Registration_System.Domain.Interfaces;
using Event_Registration_System.Infrastructure.Implementation.Repository;
using Event_Registration_System.Infrastructure.Implementation.UseCase.Auth;
using Event_Registration_System.Infrastructure.Implementation.UseCase.Event;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserEventRepository, UserEventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAuth, Auth>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEventManagement, EventManagement>();
            services.AddScoped<IUserEventManagement, UserEventManagement>();

            return services;
        }
    }
}

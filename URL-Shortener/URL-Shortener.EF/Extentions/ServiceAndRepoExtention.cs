using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL_Shortener.EF.Implementation.Repository.Domain;
using URL_Shortener.EF.Implementation.Services;
using URL_Shortener.EF.Interface.Domain;
using URL_Shortener.EF.Interface.Services;

namespace URL_Shortener.EF.Extentions
{
    public static class ServiceAndRepoExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IShortenedLinksService, ShortenedLinksService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShortenedLinksRepository, ShortenedLinksRepository>();

            return services;
        }
    }
}

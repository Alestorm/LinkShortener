using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkShortener.EFCore;
using LinkShortener.UseCases;

namespace LinkShortener.InversionOfControl
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddRepositories(connectionString);
            services.AddServices();

            return services;
        }
    }
}

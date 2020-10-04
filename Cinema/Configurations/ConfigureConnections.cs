using Cinema.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
          IConfiguration configuration)
        {
            services
                .AddDbContext<CinemaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Cinema"),
                b => b.MigrationsAssembly("Cinema.API")));

            return services;
        }
    }
}

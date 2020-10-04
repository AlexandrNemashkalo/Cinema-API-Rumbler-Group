using Cinema.Core.EF;
using Cinema.Core.Interfaces;
using Cinema.Core.Repository;
using Cinema.Core.Services;
using Cinema.Data.Entities;
using Cinema.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cinema.API.Configurations
{
    public static class ServicesConfiguration
    {


        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services  
                .AddTransient<IMovieRepository, MovieRepository>()
                .AddTransient<IHallRepository, HallRepository>()
                .AddTransient<IBookingRepository, BookingRepository>()
                .AddTransient<ISessionRepository, SessionRepository>()
                .AddTransient<ISeatRepository, SeatRepository>()
                .AddTransient<IUserRepository, UserRepository>()

                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IJwtGenerator, JwtGenerator>();
                
            return services;
        }

        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole<Guid>>(o =>
                {
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireLowercase = false;
                })
                .AddEntityFrameworkStores<CinemaContext>()
                .AddDefaultTokenProviders();

            return services;
        }


        public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = true,
                            ValidAudience = configuration["Audience"],
                            ValidateIssuer = true,
                            ValidIssuer = configuration["Issuer"],
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Key"])),
                            ValidateLifetime = false
                        };

                    });

            return services;
        }
    }
}

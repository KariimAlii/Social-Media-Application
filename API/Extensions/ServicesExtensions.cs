using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Implementation;
using ServiceLayer.Services.Interfaces;
using DataAccessLayer.Data;

namespace API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}

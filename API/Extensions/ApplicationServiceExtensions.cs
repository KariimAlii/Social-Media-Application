using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Implementation;
using ServiceLayer.Services.Interfaces;
using DataAccessLayer.Data;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , ConfigurationManager config)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Connection1"));
                //options.UseLazyLoadingProxies();

            }, ServiceLifetime.Singleton);
            return services;
        }
    }
}

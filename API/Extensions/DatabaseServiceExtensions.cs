using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Implementation;
using ServiceLayer.Services.Interfaces;
using DataAccessLayer.Data;

namespace API.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {

                var LocalConnectionString = services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Connection1");
                options.UseSqlServer(LocalConnectionString);
                //options.UseLazyLoadingProxies();

            });
            //}, ServiceLifetime.Singleton);
            return services;
        }
    }
}

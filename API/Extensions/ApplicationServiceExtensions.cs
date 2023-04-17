using API.Data;
using API.Services.Contracts;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        //public static void AddApplicationServices(ref WebApplicationBuilder builder)
        //{
        //    builder.Services.AddSingleton<IUser, UserDB>();
        //    builder.Services.AddScoped<ITokenService, TokenService>();
        //    var _builder = builder;
        //    builder.Services.AddDbContext<DataContext>(options =>
        //    {
        //        options.UseSqlServer(_builder.Configuration.GetConnectionString("Connection1"));
        //        //options.UseLazyLoadingProxies();

        //    }, ServiceLifetime.Singleton);
        //}

        // To Call at Program.cs ===> ApplicationServiceExtensions.AddApplicationServices(ref builder);

        public static IServiceCollection AddApplicationServices(this IServiceCollection services , ConfigurationManager config)
        {
            services.AddSingleton<IUser, UserDB>();
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

using AutoMapper;
using ServiceLayer.AutoMapper;

namespace API.Extensions
{
    public static class AutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            var automapper = new MapperConfiguration(item => item.AddProfile(new AutoMapperHandler()));
            IMapper mapper = automapper.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}

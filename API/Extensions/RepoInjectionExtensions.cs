using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.Implementation;
using ServiceLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Repositories.Implementation;
using EntityLayer.Entities;
using DataAccessLayer.UnitOfWork;

namespace API.Extensions
{
    public static class RepoInjectionExtensions
    {
        public static IServiceCollection AddRepoInjection(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}

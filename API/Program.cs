
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyPolicy = "_MyPolicy";
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyPolicy, policy =>
                {
                    policy.WithOrigins("https://localhost:4200/")   // you can use .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
                // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
                // https://code-maze.com/enabling-cors-in-asp-net-core/
            builder.Services.AddSingleton<IUser, UserDB>();
            builder.Services.AddDbContext<DataContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("Connection1"));
                //a.UseLazyLoadingProxies();

            }, ServiceLifetime.Singleton);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.Headers.Add("Access-Control-Allow-Methods", "*");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "*");
                context.Response.Headers.Add("Access-Control-Max-Age", "86400");
                await next();
            });
            app.UseHttpsRedirection();
            app.UseCors(MyPolicy);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
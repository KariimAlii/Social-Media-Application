
using API.Data;
using API.Extensions;
using API.Services;
using API.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Getting Configuration from App.Settings
            // First Method
            //==============
            //var provider = builder.Services.BuildServiceProvider();
            //var configuration = provider.GetRequiredService<IConfiguration>();
            //var tokenKey = configuration.GetValue<string>("TokenKey");

            // Second Method
            //==============
            // use builder.Configuration
            //var tokenKey = builder.Configuration.GetValue<string>("TokenKey");
            #endregion


            // Add services to the container.

            builder.Services.AddControllers();

            //
            builder.Services.AddApplicationServices(builder.Configuration);

            var PolicyName = "_PolicyName";
            builder.Services.AddCorsServices(PolicyName);

            builder.Services.AddIdentityServices(builder.Configuration);

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
            app.UseCors(PolicyName);

            app.UseAuthentication();
            app.UseAuthorization();

            // Note : ( UseCors ==> UseAuthentication ==> UseAuthorization ) have to be in this order
            app.MapControllers();

            app.Run();
        }
    }
}
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        //public static void AddIdentityServices(ref WebApplicationBuilder builder)
        //{
        //    var _builder = builder;
        //    builder.Services
        //        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            var tokenKey = _builder.Configuration.GetValue<string>("TokenKey");
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true, // our server will sign the token
        //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
        //                ValidateIssuer = false,  // API Server
        //                ValidateAudience = false, // Angular App
        //            };
        //        });
        //}
        // To Call at Program.cs ===> //IdentityServiceExtensions.AddIdentityServices(ref builder);

        public static IServiceCollection AddIdentityServices(this IServiceCollection services , ConfigurationManager config)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var tokenKey = config.GetValue<string>("TokenKey");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true, // our server will sign the token
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidateIssuer = false,  // API Server
                        ValidateAudience = false, // Angular App
                    };
                });
            return services;
        }
    }
}

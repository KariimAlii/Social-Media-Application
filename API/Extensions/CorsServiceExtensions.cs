namespace API.Extensions
{
    public static class CorsServiceExtensions
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services , string PolicyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: PolicyName, policy =>
                {
                    policy.WithOrigins("https://localhost:4200/")   // you can use .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            // https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-7.0
            // https://code-maze.com/enabling-cors-in-asp-net-core/
            return services;
        }
    }
}

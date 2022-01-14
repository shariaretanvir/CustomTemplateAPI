using Microsoft.Extensions.DependencyInjection;

namespace CustomTemplateAPI.Infrastructures
{
    public static class CORSExtensions
    {
        public static IServiceCollection CustomCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(c =>
                {
                    c.WithOrigins("https://localhost")
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}

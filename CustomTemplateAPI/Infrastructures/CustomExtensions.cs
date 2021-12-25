using CustomTemplateAPI.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace CustomTemplateAPI.Infrastructures
{
    public static class CustomExtensions
    {
        public static IServiceCollection CustomInfraStructure(this IServiceCollection services)
        {
            services.AddScoped<RequestResponseLoggingFilterAttribute>();
            services.AddScoped<CustomValidationFilterAttribute>();
            return services;
        }
    }
}

using CustomTemplateAPI.RepositoryLayer.Classes;
using CustomTemplateAPI.RepositoryLayer.Interfaces;
using CustomTemplateAPI.Filters;
using CustomTemplateAPI.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CustomTemplateAPI.Infrastructures
{
    public static class CustomExtensions
    {
        public static IServiceCollection CustomInfraStructure(this IServiceCollection services)
        {
            services.AddScoped<RequestResponseLoggingFilterAttribute>();
            services.AddScoped<CustomValidationFilterAttribute>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
            services.AddScoped<IServiceUnitOfWork, ServiceUnitofWork1>();
            return services;
        }
    }
}

using CustomTemplateAPI.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CustomTemplateAPI.Infrastructures
{
    public static class GlobalErrorExtension
    {
        public static IApplicationBuilder GlobalErrorHandler(this IApplicationBuilder app) =>
            app.UseMiddleware<GlobalExceptionMiddleware>();
    }
}

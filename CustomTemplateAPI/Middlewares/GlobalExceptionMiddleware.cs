using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionMiddleware> logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
                if(context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    await PrepareUnAuthorizeResponse(context,logger);
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                await PrepareErrorResponse(context,logger,e);
            }
        }

        private async Task PrepareErrorResponse(HttpContext context, ILogger<GlobalExceptionMiddleware> logger,Exception exception)
        {
            //var statusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var response = JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = exception.Message
            });
            await context.Response.WriteAsync(response);
        }

        private async Task PrepareUnAuthorizeResponse(HttpContext context, ILogger<GlobalExceptionMiddleware> logger)
        {
            var response = JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Unauthorize !! Provide valid information to get data."
            });
            await context.Response.WriteAsync(response);
        }
    }
}

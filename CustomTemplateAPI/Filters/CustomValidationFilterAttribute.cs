using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace CustomTemplateAPI.Filters
{
    public class CustomValidationFilterAttribute : IAsyncActionFilter
    {
        public ILogger<CustomValidationFilterAttribute> logger { get; }
        public CustomValidationFilterAttribute(ILogger<CustomValidationFilterAttribute> logger)
        {
            logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(t => t.Errors.Count > 0)
                         .SelectMany(t => t.Errors)
                         .Select(t => t.ErrorMessage)
                         .ToList();
                context.Result = new BadRequestObjectResult(new
                {
                    Reason = "Validation Failed!!",
                    Errors = errors
                });
                logger.LogError($"Validation Error!! Error message : {errors}");
                return;
            }
            await next();
        }
    }
}

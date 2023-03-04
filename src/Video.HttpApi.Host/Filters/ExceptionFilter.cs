using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Video.Domain.Shared;
using Video.HttpApi.Host.Views;

namespace Video.HttpApi.Host.Filters
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var ex = context.Exception;
            _logger.LogError($"Path {context.HttpContext.Request.Path} message {context.Exception} ");
            if(ex is BusinessException exception)
            {
                context.Result = new OkObjectResult(new ResponseView(exception.Code,ex.Message));
            }
            else
            {
            context.Result = new OkObjectResult(new ResponseView(500, ex.Message));
            }
            context.ExceptionHandled= true;

            return Task.CompletedTask;
        }
    }
}

using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Shared.Infrastructure.Middlewares
{
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider, ILogger<CustomExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {

            if (!isApplication(context.HttpContext.Request.ContentType))
            {
                return Task.CompletedTask;
            }
            Alert alert;

            if (context.Exception is AppError)
            {
                alert = new Alert(AlertType.warning);
                var exception = (AppError)context.Exception;
                alert.Text = ((string)exception._message);
                _logger.LogInformation(exception, (string)exception._message);
            }
            else
            {
                alert = new Alert(AlertType.error);
                alert.Text = context.Exception.Message;
                _logger.LogError(context.Exception, context.Exception.InnerException?.Message ?? context.Exception.Message);
            }
            alert.ShowAlert(context);

            context.Result = new PageResult();
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
        private bool isApplication(string type)
        {
            switch (type)
            {
                case null:
                case "application/x-www-form-urlencoded":
                    return true;
                default:
                    return false;
            }
        }
    }
}

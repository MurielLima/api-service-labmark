using System;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

            if (!isApplication(context.HttpContext.Request))
            {
                return Task.CompletedTask;
            }
            Alert alert;

            if (context.Exception is AppError)
            {
                alert = new Alert(AlertType.warning);
                var exception = (AppError)context.Exception;
                alert.Text = exception._message as string ?? string.Empty;
                _logger.LogInformation(exception, exception._message as string ?? string.Empty);
            }
            else if(context.Exception is DbUpdateException)
            {
                alert = new Alert(AlertType.error);
                alert.Text = context.Exception.InnerException?.Message;
                alert.Text = alert.Text.Replace("An error was raised during trigger execution. The batch has been aborted and the user transaction, if any, has been rolled back.", "").Replace("\n","");
                _logger.LogError(context.Exception, context.Exception.InnerException?.Message ?? context.Exception.Message);
            }
            else
            {
                alert = new Alert(AlertType.error);
                alert.Text = context.Exception.InnerException?.Message ?? context.Exception.Message;
                _logger.LogError(context.Exception, context.Exception.InnerException?.Message ?? context.Exception.Message);
            }
            alert.ShowAlert(context);

            context.Result = isApplication(context.HttpContext.Request) ? new PageResult() : null;
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
        private bool isApplication(HttpRequest httpRequest = null)
        {
            string type = httpRequest.ContentType;
            if (type == null && httpRequest.Path.Value.Contains("api"))
                return false;
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

using System;
using System.Text;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Labmark.Domain.Shared.Infrastructure.Middlewares
{
    public class CustomExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if (!isApplication(context.HttpContext.Request.ContentType))
            {
                return;
            }
            Alert alert;

            if (context.Exception is AppError)
            {
                alert = new Alert(AlertType.warning);
                var exception = (AppError)context.Exception;
                alert.Text = ((string)exception._message);
            }
            else
            {
                alert = new Alert(AlertType.error);
                alert.Text = context.Exception.Message;
            }
            alert.ShowAlert(context.HttpContext.Response.Headers);

            context.Result = new PageResult();
            context.ExceptionHandled = true;
            return;
        }
        private bool isApplication(string type)
        {
            switch (type)
            {
                case "application/x-www-form-urlencoded":
                    return true;
                default:
                    return false;
            }
        }
    }
}

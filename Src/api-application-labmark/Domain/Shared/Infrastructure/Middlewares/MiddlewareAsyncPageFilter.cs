using System;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Labmark.Domain.Shared.Infrastructure.Middlewares
{
    public class MiddlewareAsyncPageFilter : IAsyncPageFilter
    {
        private readonly IConfiguration _config;

        public MiddlewareAsyncPageFilter(IConfiguration config)
        {
            _config = config;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                      PageHandlerExecutionDelegate next)
        {
            try
            {
                // Do post work.
                await next.Invoke();
            }
            catch (AppError ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            return Task.CompletedTask;
        }
    }
}

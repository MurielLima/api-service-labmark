using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Labmark.Domain.Shared.Infrastructure.Middlewares
{
    public class MiddlewarePageFilter : IPageFilter
    {
        private readonly IConfiguration _config;

        public MiddlewarePageFilter(IConfiguration config)
        {
            _config = config;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            Debug.WriteLine("Global sync OnPageHandlerExecuting called.");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Debug.WriteLine("Global sync OnPageHandlerExecuting called.");
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Debug.WriteLine("Global sync OnPageHandlerExecuted called.");
        }
    }
}

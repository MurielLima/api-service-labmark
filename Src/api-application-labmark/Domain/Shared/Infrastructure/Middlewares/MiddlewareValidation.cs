using System;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Shared.Infrastructure.Middlewares
{
    public class MiddlewareValidation : IMiddleware
    {
        private readonly ILogger<MiddlewareValidation> _logger;

        public MiddlewareValidation(ILogger<MiddlewareValidation> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (AppError ex)
            {
                context.Response.StatusCode = ex._statusCode;
                await context.Response.WriteAsJsonAsync<ResponseDto>(new ResponseDto("warning", ex._message));
                _logger.LogWarning(ex, ex.Message);
                return;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync<ResponseDto>(new ResponseDto("error", ex.Message));
                _logger.LogError(ex, ex.Message);
                return;
            }
        }
        private bool isJson(string json)
        {
            switch (json)
            {
                case "application/*+json":
                case "text/json":
                case "application/json":
                    return true;
                default:
                    return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Shared.Infrastructure.Middlewares;
using Labmark.Domain.Shared.Infrastructure.Providers;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Domain.Shared.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Shared
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IMailProvider, SendGridProvider>();
            services.AddTransient<MiddlewareValidation>();
            services.AddTransient<ITemplateMailProvider, TemplateMailProvider>();
            services.AddSingleton<AuthMessageSenderOptionsDto>();
        }
    }
}

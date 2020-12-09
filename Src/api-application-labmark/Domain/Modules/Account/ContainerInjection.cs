using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.Services;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Providers;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Domain.Shared.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Account
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ILoginUserService,LoginUserService>();
            services.AddTransient<ILogoutUserService, LogoutUserService>();
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<IConfirmAccountService, ConfirmAccountService>();
            services.AddTransient<ISendEmailConfirmationService, SendEmailConfirmationService>();
            services.AddTransient<IMailProvider, SendGridProvider>();
            services.AddTransient<ITemplateMailProvider, TemplateMailProvider>();
            services.AddSingleton<AuthMessageSenderOptionsDto>();
        }
    }
}

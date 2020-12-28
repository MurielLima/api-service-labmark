using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Account.Infrastructure.Services;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Domain.Shared.Infrastructure.Middlewares;
using Labmark.Domain.Shared.Infrastructure.Providers;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Domain.Shared.Providers;
using Labmark.Infrastructure.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Account
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IAccountController, AccountController>();
            services.AddTransient<ILoginUserService, LoginUserService>();
            services.AddTransient<ILogoutUserService, LogoutUserService>();
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<IListUserService, ListUserService>();
            services.AddTransient<IUpdateUserService, UpdateUserService>();
            services.AddTransient<IConfirmAccountService, ConfirmAccountService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ISendEmailConfirmationService, SendEmailConfirmationService>();
            services.AddTransient<IMailProvider, SendGridProvider>();
            services.AddTransient<MiddlewareValidation>();
            services.AddTransient<ITemplateMailProvider, TemplateMailProvider>();
            services.AddSingleton<AuthMessageSenderOptionsDto>();
        }
    }
}

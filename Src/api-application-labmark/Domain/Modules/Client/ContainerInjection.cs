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

namespace Labmark.DependencyInjection
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Controllers
            services.AddTransient<IAccountController, AccountController>();
            #endregion

            #region Services
            services.AddTransient<ILoginUserService, LoginUserService>();
            services.AddTransient<ILogoutUserService, LogoutUserService>();
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<IListUserService, ListUserService>();
            services.AddTransient<IUpdateUserService, UpdateUserService>();
            services.AddTransient<IConfirmAccountService, ConfirmAccountService>();
            services.AddTransient<ISendEmailConfirmationService, SendEmailConfirmationService>();
            services.AddTransient<IResetPasswordService, ResetPasswordService>();
            #endregion

            #region Repositories
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            #endregion

            services.AddTransient<IMailProvider, SendGridProvider>();
            services.AddTransient<MiddlewareValidation>();
            services.AddTransient<ITemplateMailProvider, TemplateMailProvider>();
            services.AddSingleton<AuthMessageSenderOptionsDto>();
        }
    }
}

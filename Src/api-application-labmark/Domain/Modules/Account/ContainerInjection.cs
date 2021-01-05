using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Account.Infrastructure.Services;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Account.Services;
using Labmark.Infrastructure.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Account
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
        }
    }
}

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

namespace Labmark.Domain.Modules.Client
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Controllers
            #endregion

            #region Services

            #endregion

            #region Repositories
            #endregion
        }
    }
}

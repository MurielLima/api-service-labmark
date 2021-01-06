using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Client.Infrastructure.Services;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Modules.Client.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Client
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Controllers
            services.AddTransient<IClientController, ClientController>();
            #endregion

            #region Services
            services.AddTransient<ICreateClientService, CreateClientService>();
            services.AddTransient<IUpdateClientService, UpdateClientService>();
            services.AddTransient<IListClientService, ListClientService>();
            #endregion

            #region Repositories
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            #endregion
        }
    }
}

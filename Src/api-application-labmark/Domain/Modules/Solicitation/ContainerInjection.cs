using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Solicitation
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Controllers
            services.AddTransient<ISolicitationController, SolicitationController>();
            #endregion

            #region Services
            //services.AddTransient<ICreateClientService, CreateClientService>();
            #endregion

            #region Repositories
            //services.AddTransient<IPessoaRepository, PessoaRepository>();
            #endregion
        }
    }
}

using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Services;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Modules.Solicitation.Services;
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
            services.AddTransient<ICreateSolicitationService, CreateSolicitationService>();
            services.AddTransient<IUpdateSolicitationService, UpdateSolicitationService>();
            services.AddTransient<IListSolicitationService, ListSolicitationService>();
            #endregion

            #region Repositories
            services.AddTransient<IPerguntaRepository, PerguntaRepository>();
            services.AddTransient<ISolicitacaoRepository, SolicitacaoRepository>();
            #endregion
        }
    }
}

using Labmark.Controllers;
using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Exam.Infrastructure.Services.CountMBLB;
using Labmark.Domain.Modules.Exam.Infrastructure.Services.EscherichiaColiforms;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Modules.Exam.Services.CountMBLB;
using Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Sample.Infrastructure.Services;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.DilutionSample;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.Experiment;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services;
using Labmark.Domain.Modules.Sample.Services.DilutionSample;
using Labmark.Domain.Modules.Sample.Services.Experiment;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.Exam
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region CountMBLB
            #region Controllers
            services.AddTransient<ICountMBLBController, CountMBLBController>();
            #endregion

            #region Services
            services.AddTransient<ICreateCountMBLBService, CreateCountMBLBService>();
            services.AddTransient<IUpdateCountMBLBService, UpdateCountMBLBService>();
            //services.AddTransient<IListCountMBLBService, ListCountMBLBService>();
            #endregion

            #region Repositories
            services.AddTransient<IContagemMBLBRepository, ContagemMBLBRepository>();
            #endregion
            #endregion

            #region EscherichiaColiforms
            #region Controllers
            services.AddTransient<IEscherichiaColiformsController, EscherichiaColiformsController>();
            #endregion

            #region Services
            services.AddTransient<ICreateEscherichiaColiformsService, CreateEscherichiaColiformsService>();
            services.AddTransient<IUpdateEscherichiaColiformsService, UpdateEscherichiaColiformsService>();
            //services.AddTransient<IListEscherichiaColiformsService, ListEscherichiaColiformsService>();
            #endregion

            #region Repositories
            services.AddTransient<IColiformesEscherichiaRepository, ColiformesEscherichiaRepository>();
            #endregion
            #endregion

        }
    }
}

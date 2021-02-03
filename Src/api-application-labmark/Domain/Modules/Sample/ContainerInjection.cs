using Labmark.Controllers;
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

namespace Labmark.Domain.Modules.Sample
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Sample
            #region Controllers
            services.AddTransient<ISampleController, SampleController>();
            #endregion

            #region Services
            services.AddTransient<ICreateSampleService, CreateSampleService>();
            services.AddTransient<IUpdateSampleService, UpdateSampleService>();
            services.AddTransient<IListSampleService, ListSampleService>();
            #endregion

            #region Repositories
            services.AddTransient<IAmostraRepository, AmostraRepository>();
            #endregion
            #endregion

            #region DilutionDilutionSample
            #region Controllers
            services.AddTransient<IDilutionSampleController, DilutionSampleController>();
            #endregion

            #region Services
            services.AddTransient<ICreateDilutionSampleService, CreateDilutionSampleService>();
            services.AddTransient<IUpdateDilutionSampleService, UpdateDilutionSampleService>();
            services.AddTransient<IListDilutionSampleService, ListDilutionSampleService>();
            #endregion

            #region Repositories
            services.AddTransient<IDiluicaoAmostraRepository, DiluicaoAmostraRepository>();
            #endregion
            #endregion

            #region Experiment
            #region Controllers
            services.AddTransient<IExperimentController, ExperimentController>();
            #endregion

            #region Services
            services.AddTransient<ICreateExperimentService, CreateExperimentService>();
            services.AddTransient<IUpdateExperimentService, UpdateExperimentService>();
            services.AddTransient<IListExperimentService, ListExperimentService>();
            #endregion

            #region Repositories
            services.AddTransient<IExperimentoRepository, ExperimentoRepository>();
            #endregion
            #endregion
        }
    }
}

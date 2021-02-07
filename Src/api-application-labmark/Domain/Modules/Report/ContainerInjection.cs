using Labmark.Controllers;
using Labmark.Domain.Modules.DilutionSample.Infrastructure.Services.DilutionSample;
using Labmark.Domain.Modules.Experiment.Infrastructure.Services.Experiment;
using Labmark.Domain.Modules.ReportSample.Controllers;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Repositories;
using Labmark.Domain.Modules.Sample.Infrastructure.Services;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.Assay;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.DilutionSample;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.Experiment;
using Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services;
using Labmark.Domain.Modules.Sample.Services.Assay;
using Labmark.Domain.Modules.Sample.Services.DilutionSample;
using Labmark.Domain.Modules.Sample.Services.Experiment;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain.Modules.ReportSample
{
    public static partial class ContainerInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Sample
            #region Controllers
            services.AddTransient<IReportController, ReportController>();
            #endregion
            #endregion
        }
    }
}

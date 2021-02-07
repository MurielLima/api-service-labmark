using Microsoft.Extensions.DependencyInjection;

namespace Labmark.Domain
{
    public static partial class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            Shared.ContainerInjection.Register(services);

            Modules.Account.ContainerInjection.Register(services);
            Modules.Client.ContainerInjection.Register(services);
            Modules.Solicitation.ContainerInjection.Register(services);
            Modules.Sample.ContainerInjection.Register(services);
            Modules.Exam.ContainerInjection.Register(services);
            Modules.ReportSample.ContainerInjection.Register(services);
        }
    }
}

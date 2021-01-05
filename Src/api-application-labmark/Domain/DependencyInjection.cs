using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }
    }
}

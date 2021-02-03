using Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Incubation.Repositories
{
    public interface IIncubationRepository : IRepository<Incubacao>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Sample.Repositories
{
    public interface IEnsaioRepository : IRepository<Ensaio>
    {
    }
}

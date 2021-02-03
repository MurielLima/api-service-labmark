using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Repositories
{
    public class EnsaioRepository : Repository<Ensaio>, IEnsaioRepository
    {
        public EnsaioRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

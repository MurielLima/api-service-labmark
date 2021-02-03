using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Repositories
{
    public class AmostraRepository : Repository<Amostra>, IAmostraRepository
    {
        public AmostraRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

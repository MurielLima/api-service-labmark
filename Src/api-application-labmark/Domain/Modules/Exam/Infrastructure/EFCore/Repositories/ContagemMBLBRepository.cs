using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Repositories
{
    public class ContagemMBLBRepository : Repository<ContagemMBLB>, IContagemMBLBRepository
    {
        public ContagemMBLBRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}

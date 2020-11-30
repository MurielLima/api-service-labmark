using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Pessoa> FindByEmail(string email)
        {
            return await dbSet.FindAsync(new {Email = email});
        }
    }
}

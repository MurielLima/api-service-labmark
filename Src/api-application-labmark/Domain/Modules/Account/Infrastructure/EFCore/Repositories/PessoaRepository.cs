using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Pessoa> FindByEmail(string email)
        {
            return await dbSet.FindAsync(new { Email = email, TipoAcesso = 'U' });
        }
        public async Task<IList<Pessoa>> ListAllUsers()
        {
            return await this.Get(x => x.TipoAcesso.Equals('U'));
        }
        public async override Task<Pessoa> GetByID(int id)
        {
            return await dbSet.FindAsync(new { Id = id, TipoAcesso = 'U'});
        }
        public override bool Save(Pessoa entity)
        {
            entity.TipoAcesso = 'U';
            return base.Save(entity);
        }
        public override bool Insert(Pessoa entity)
        {
            entity.TipoAcesso = 'U';
            return base.Insert(entity);
        }
    }
}

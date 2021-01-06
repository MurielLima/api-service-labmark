using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Shared.Infrastructure.EFCore;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Client.Infrastructure.EFCore.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Pessoa> FindByEmail(string email)
        {
            return await dbSet.FindAsync(new { Email = email });
        }
        public async Task<IList<Pessoa>> ListAllClients()
        {
            return await this.Get(x => x.TipoAcesso.Equals('C'));
        }
        public async override Task<Pessoa> GetByID(int id)
        {
            return await dbSet.FindAsync(new { Id = id, TipoAcesso = 'C' });
        }
        public override bool Save(Pessoa entity)
        {
            entity.TipoAcesso = 'C';
            return base.Save(entity);
        }
        public override bool Insert(Pessoa entity)
        {
            entity.TipoAcesso = 'C';
            return base.Insert(entity);
        }
    }
}

using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Account.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        public Task<Pessoa> FindByEmail(string email);
    }
}

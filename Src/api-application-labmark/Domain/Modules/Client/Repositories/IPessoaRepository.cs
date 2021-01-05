using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Repositories;

namespace Labmark.Domain.Modules.Client.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        public Task<Pessoa> FindByEmail(string email);
    }
}

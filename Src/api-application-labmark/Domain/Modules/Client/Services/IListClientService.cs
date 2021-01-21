using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Services
{
    public interface IListClientService
    {
        public Task<IList<ClientDto>> Execute(int? clientId);
    }
}

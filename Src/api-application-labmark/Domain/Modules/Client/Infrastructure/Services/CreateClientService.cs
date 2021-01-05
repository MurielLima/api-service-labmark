using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Factories;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Modules.Client.Services;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Client.Infrastructure.Services
{
    public class CreateClientService : ICreateClientService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<ICreateClientService> _logger;
        public async Task<ClientDto> Execute(ClientDto clientDto)
        {
            Pessoa pessoa = PessoaFactory.Factory(new Pessoa(), clientDto);
            _pessoaRepository.Insert(pessoa);
            await _pessoaRepository.Commit();
            return clientDto;
        }
    }
}

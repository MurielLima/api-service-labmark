using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Mappers;
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

        public CreateClientService(ILogger<ICreateClientService> logger, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ClientDto> Execute(ClientDto clientDto)
        {
            Pessoa pessoa = ClientDtoMapToPessoa.Map(new Pessoa(), clientDto);

            _pessoaRepository.Insert(pessoa);
            await _pessoaRepository.Commit();
            return clientDto;
        }
    }
}

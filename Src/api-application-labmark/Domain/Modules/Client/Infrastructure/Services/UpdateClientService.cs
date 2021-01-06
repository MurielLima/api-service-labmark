using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Factories;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Modules.Client.Services;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Client.Infrastructure.Services
{
    public class UpdateClientService : IUpdateClientService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<IUpdateClientService> _logger;

        public UpdateClientService(ILogger<IUpdateClientService> logger, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<ClientDto> Execute(ClientDto clientDto)
        {
            Pessoa pessoa = await _pessoaRepository.GetByID(clientDto.Id);
            pessoa = PessoaFactory.Factory(pessoa, clientDto);

            _pessoaRepository.Save(pessoa);
            await _pessoaRepository.Commit();
            return clientDto;
        }
    }
}

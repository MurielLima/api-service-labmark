using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Factories;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Modules.Client.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Client.Infrastructure.Services
{
    public class ListClientService : IListClientService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<IListClientService> _logger;

        public ListClientService(ILogger<IListClientService> logger, IPessoaRepository pessoaRepository)
        {
            _logger = logger;
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IList<ClientDto>> Execute(int? clientId)
        {
            IList<Pessoa> pessoas = new List<Pessoa>();
            IList<ClientDto> clientDtos = new List<ClientDto>();

            if (clientId > 0)
            {
                Pessoa pessoa = await _pessoaRepository.GetByID((int)clientId);
                if (pessoa != null)
                {
                    pessoas.Add(pessoa);
                }
            }
            else
            {
                pessoas = await _pessoaRepository.ListAllClients();
            }
            if (pessoas.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhum cliente.", 404);
            }
            foreach (Pessoa x in pessoas)
            {
                clientDtos.Add(ClientFactory.Factory(x, new ClientDto()));
            }

            return clientDtos;
        }
    }
}

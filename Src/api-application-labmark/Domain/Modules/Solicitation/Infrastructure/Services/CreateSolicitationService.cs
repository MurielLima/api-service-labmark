using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Repositories;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Modules.Solicitation.Services;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Services
{
    public class CreateSolicitationService : ICreateSolicitationService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        public CreateSolicitationService(IPessoaRepository pessoaRepository, ISolicitacaoRepository solicitacaoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<SolicitationDto> Execute(SolicitationDto solicitationDto, int clientId)
        {
            Pessoa client = await _pessoaRepository.GetByID(clientId);
            Solicitacao solicitacao = SolicitationDtoMapToSolicitacao.Map(new Solicitacao(), solicitationDto);
            solicitacao.fkCliente = client;

            _solicitacaoRepository.Insert(solicitacao);

            return solicitationDto;
        }
    }
}

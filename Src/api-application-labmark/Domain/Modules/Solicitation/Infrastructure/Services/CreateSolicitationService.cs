using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Repositories;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Modules.Solicitation.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

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
            if(solicitationDto.AskDtos.Count() < 5)
            {
                throw new AppError("Responda todas as questões!");
            }
            if (clientId == 0)
            {
                throw new AppError("Escolha um cliente válido!");
            }
            Pessoa client = await _pessoaRepository.GetByID(clientId);
            if(client == null)
            {
                throw new AppError("Cliente não encontrado!", 404);
            }
            if(solicitationDto.ReceivingDate > DateTime.Now)
            {
                throw new AppError("Data de recebimento não pode ser uma data futura");
            }
            Solicitacao solicitacao = SolicitationDtoMapToSolicitacao.Map(new Solicitacao(), solicitationDto);
            solicitacao.fkPessoa = client;
            solicitacao.fkPessoaId = client.Id;

            _solicitacaoRepository.Insert(solicitacao);
            await _solicitacaoRepository.Commit();
            solicitationDto.Id = solicitacao.Id;
            return solicitationDto;
        }
    }
}

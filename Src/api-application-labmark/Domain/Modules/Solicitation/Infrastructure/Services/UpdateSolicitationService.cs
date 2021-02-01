using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Modules.Solicitation.Services;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Services
{
    public class UpdateSolicitationService : IUpdateSolicitationService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        public UpdateSolicitationService(ISolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<SolicitationDto> Execute(SolicitationDto solicitationDto)
        {
            Solicitacao solicitacao = await _solicitacaoRepository.GetByID(solicitationDto.Id);
            SolicitationDtoMapToSolicitacao.Map(solicitacao, solicitationDto);

            _solicitacaoRepository.Save(solicitacao);

            return solicitationDto;
        }
    }
}

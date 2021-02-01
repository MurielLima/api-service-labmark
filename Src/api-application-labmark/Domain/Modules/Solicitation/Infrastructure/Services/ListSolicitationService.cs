using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Modules.Solicitation.Services;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Services
{
    public class ListSolicitationService : IListSolicitationService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        public ListSolicitationService(ISolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<IList<SolicitationDto>> Execute(int? solicitationId)
        {
            IList<Solicitacao> solicitacoes = new List<Solicitacao>();
            IList<SolicitationDto> solicitationDtos = new List<SolicitationDto>();
            if (solicitationId > 0)
            {
                Solicitacao solicitacao = await _solicitacaoRepository.GetByID((int)solicitationId);
                if(solicitacao != null)
                {
                    solicitacoes.Add(solicitacao);
                }
            }else{
                solicitacoes = await _solicitacaoRepository.Get();
            }
            foreach(var solicitacao in solicitacoes)
            {
                solicitationDtos.Add(SolicitacaoMapToSolicitationDto.Map(new SolicitationDto(), solicitacao));
            }
            if (solicitationDtos.Count() == 0)
            {
                throw new AppError("Não foi encontrado nenhuma solcitação.", 404);
            }

            return solicitationDtos;
        }
    }
}

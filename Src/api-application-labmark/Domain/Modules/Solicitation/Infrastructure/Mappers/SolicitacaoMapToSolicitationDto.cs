using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers
{
    public static class SolicitacaoMapToSolicitationDto
    {
        public static SolicitationDto Map(SolicitationDto solicitationDto, Solicitacao solicitacao)
        {
            solicitationDto.Id = solicitacao.Id;
            solicitationDto.clientDto = solicitationDto.clientDto ?? new ClientDto();
            solicitationDto.clientDto.Id = solicitacao.fkPessoaId ?? 0;
            solicitationDto.Observation = solicitacao.Observacao;
            solicitationDto.CompletionDate = solicitacao.DataConclusao ?? new DateTime();
            solicitationDto.ReceivingDate = solicitacao.DataRecebimento;
            solicitationDto.AskDtos = new List<AskDto>();
            foreach (var pergunta in solicitacao.fkPerguntas)
            {
                solicitationDto.AskDtos.Add(PerguntaMapToAskDto.Map(new AskDto(), pergunta));
            }
            
            return solicitationDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Client.Infrastructure.Mappers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers
{
    public static class SolicitationDtoMapToSolicitacao
    {
        public static Solicitacao Map(Solicitacao solicitacao, SolicitationDto solicitationDto)
        {
            solicitacao.Id = solicitationDto.Id;
            solicitacao.fkCliente = ClientDtoMapToPessoa.Map(new Pessoa(), solicitationDto.clientDto);
            solicitacao.fkPessoaId = solicitationDto.clientDto.Id;
            solicitacao.Observacao = solicitationDto.Observation;
            solicitacao.DataRecebimento = solicitationDto.ReceivingDate;
            solicitacao.DataConclusao = solicitationDto.CompletionDate;
            solicitacao.fkPerguntas = new List<Pergunta>();
            foreach (var ask in solicitationDto.AskDtos)
            {
                solicitacao.fkPerguntas.Add(AskDtoMapToPergunta.Map(new Pergunta(), ask));
            }
            return solicitacao;
        }
    }
}

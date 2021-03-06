﻿using System;
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
            solicitacao.fkPessoa = solicitationDto.clientDto != null ? ClientDtoMapToPessoa.Map(new Pessoa(), solicitationDto.clientDto) : null;
            solicitacao.fkPessoaId = solicitationDto.clientDto != null ? solicitationDto.clientDto.Id : null;
            solicitacao.Observacao = solicitationDto.Observation;
            solicitacao.Perguntum = new List<Pergunta>();
            foreach (var ask in solicitationDto.AskDtos)
            {
                solicitacao.Perguntum.Add(AskDtoMapToPergunta.Map(new Pergunta(), ask));
            }
            solicitacao.Julgamento = !solicitacao.Perguntum.Any(x => x.Resposta == false); 
            return solicitacao;
        }
    }
}

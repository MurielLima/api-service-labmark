using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers
{
    public static class PerguntaMapToAskDto
    {
        public static AskDto Map(AskDto askDto, Pergunta pergunta)
        {
            askDto.Code = (Models.Enums.EnumQuestion)pergunta.Codigo;
            askDto.Answer = pergunta.Resposta.Equals("S") ? "S" : "N";
            return askDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Mappers
{
    public static class AskDtoMapToPergunta
    {
        public static Pergunta Map(Pergunta pergunta, AskDto askDto)
        {
            pergunta.Codigo = (int) askDto.Code;
            pergunta.Resposta = askDto.Answer.Equals("S");
            return pergunta;
        }
    }
}

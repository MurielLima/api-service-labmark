using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class LeituraMapToReadingDto
    {
        public static Leitura Map(ReadingDto readingDto, Leitura leitura)
        {
            leitura.Id = readingDto.Id;
            leitura.Leitura1 = readingDto.Reading;
            leitura.fkDiluicoes = readingDto.Dilutions;
           



            return leitura;
        }



    }
}

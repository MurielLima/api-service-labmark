using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ReadingDtoMapToLeitura
    {
        public static Leitura Map(Leitura leitura, ReadingDto readingDto)
        {
            leitura.Id = readingDto.Id;
            leitura.Leitura1 = readingDto.Reading;
            leitura.Code = (int)readingDto.Code;
                    
            return leitura;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class LeituraMapToReadingDto
    {
       
        public static ReadingDto Map(ReadingDto readingDto, Leitura leitura)
        {
            readingDto.Id = leitura.Id;
            readingDto.Reading = leitura.Leitura1;
            readingDto.Code = (EnumReadings)leitura.Code;

            return readingDto;
        }



    }
}

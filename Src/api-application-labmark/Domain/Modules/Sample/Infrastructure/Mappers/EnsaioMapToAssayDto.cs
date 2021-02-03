using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class EnsaioMapToAssayDto
    {
        public static AssayDto Map(AssayDto assayDto, Ensaio ensaio)
        {
            assayDto.Id = ensaio.Id;
            assayDto.Methodology = ensaio.Metodologia;
            assayDto.Reference = ensaio.Referencia;

            return assayDto;
        }







    }
}

using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class ExperimentDtoMapToExperimento
    {
        public static Experimento Map(Experimento experimento, ExperimentDto experimentDto)
        {
            experimento.Id = experimentDto.Id;
            experimento.Meio = experimentDto.Middle;
            experimento.BOD = experimentDto.BOD;
            experimento.Lote = experimentDto.Lot;

            return experimento;
        }
    }
}

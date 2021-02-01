using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class ExperimentoMapToExperimentDto
    {
        public static ExperimentDto Map(ExperimentDto experimentDto, Experimento experimento)
        {
            experimentDto.Id = experimento.Id;
            experimentDto.Middle = experimento.Meio;
            experimentDto.BOD = experimento.BOD;
            experimentDto.Lot = experimento.Lote;

            return experimentDto;
        }


    }
}

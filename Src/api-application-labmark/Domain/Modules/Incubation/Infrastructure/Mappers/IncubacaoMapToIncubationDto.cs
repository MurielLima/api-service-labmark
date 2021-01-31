using Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Mappers
{
    public class IncubacaoMapToIncubationDto
    {

        public static IncubationDto Map(Incubacao incubacao, IncubationDto incubationDto)
        {
            incubationDto.Id = incubacao.Id;
            incubationDto.CompleteDate = incubacao.DataFinalizacao;
            incubationDto.IncubationTemperature = incubacao.TemperaturaIncubacao;
            


            return incubationDto;
        }
    }
}

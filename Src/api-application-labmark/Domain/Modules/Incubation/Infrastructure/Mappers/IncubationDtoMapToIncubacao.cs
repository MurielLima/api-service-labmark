using Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Mappers
{
    public class IncubationDtoMapToIncubacao
    {
        public static Incubacao Map(IncubationDto incubationDto, Incubacao incubacao)
        {
            incubacao.Id = incubationDto.Id;
            incubacao.DataFinalizacao = incubationDto.CompleteDate;
            incubacao.TemperaturaIncubacao = incubationDto.IncubationTemperature;
            



            return incubacao;
        }



    }
}

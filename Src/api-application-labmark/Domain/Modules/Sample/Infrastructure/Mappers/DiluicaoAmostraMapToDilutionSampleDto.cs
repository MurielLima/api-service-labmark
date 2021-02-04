using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class DiluicaoAmostraMapToDilutionSampleDto
    {
        public static DilutionSampleDto Map(DilutionSampleDto dilutionSampleDto, DiluicaoAmostra diluicaoAmostra)
        {
            dilutionSampleDto.Id = diluicaoAmostra.Id;
            dilutionSampleDto.Homogenizer = diluicaoAmostra.Homogeneizador;
            dilutionSampleDto.Micropipette = diluicaoAmostra.Micropipeta;
            dilutionSampleDto.Pipette = diluicaoAmostra.Pipeta;
            dilutionSampleDto.Shaker = diluicaoAmostra.Agitador;
            dilutionSampleDto.Board = diluicaoAmostra.Placa;
            dilutionSampleDto.Others = diluicaoAmostra.Outros;
            dilutionSampleDto.WaterDilutions = new List<WaterDilutionDto>();
            foreach(var x in diluicaoAmostra.fkAguaDiluicaos)
            {
                var waterDilution = new WaterDilutionDto((EnumWaterDilution)x.Codigo);
                waterDilution.Value = x.Valor;
                dilutionSampleDto.WaterDilutions.Add(waterDilution);
            }            


            return dilutionSampleDto;
        }

    }
}

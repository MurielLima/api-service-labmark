using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class DilutionSampleDtoMapToDiluicaoAmostra
    {
        public static DiluicaoAmostra Map(DiluicaoAmostra diluicaoAmostra, DilutionSampleDto dilutionSampleDto)
        {
            diluicaoAmostra.Id = dilutionSampleDto.Id;
            diluicaoAmostra.Homogeneizador = dilutionSampleDto.Homogenizer;
            diluicaoAmostra.Micropipeta; = dilutionSampleDto.Micropipette;
            diluicaoAmostra.Pipeta = dilutionSampleDto.Pipette;
            diluicaoAmostra.Agitador = dilutionSampleDto.Shaker;
            diluicaoAmostra.Placa = dilutionSampleDto.Board;
            diluicaoAmostra.Outros = dilutionSampleDto.Others;
           
            return diluicaoAmostra;
        }
    }
}

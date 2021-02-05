using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Extensions;
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
            diluicaoAmostra.Micropipeta = dilutionSampleDto.Micropipette;
            diluicaoAmostra.Pipeta = dilutionSampleDto.Pipette;
            diluicaoAmostra.Agitador = dilutionSampleDto.Shaker;
            diluicaoAmostra.Placa = dilutionSampleDto.Board;
            diluicaoAmostra.Outros = dilutionSampleDto.Others;
            diluicaoAmostra.fkAguaDiluicaos = new List<AguaDiluicao>();
            diluicaoAmostra.fkPonteiras = new List<Ponteira>();
            diluicaoAmostra.Local = (int)dilutionSampleDto.Location.Code;
            foreach (var x in dilutionSampleDto.Points)
            {
                var ponteira = new Ponteira();
                ponteira.Codigo = (int)x.Code;
                ponteira.Valor = x.Value;
                diluicaoAmostra.fkPonteiras.Add(ponteira);
            }
            foreach (var x in dilutionSampleDto.WaterDilutions)
            {
                var aguadiluicao = new AguaDiluicao();
                aguadiluicao.Codigo = (int)x.Code;
                aguadiluicao.Valor = x.Value;
                diluicaoAmostra.fkAguaDiluicaos.Add(aguadiluicao);
            }
            return diluicaoAmostra;
        }
    }
}

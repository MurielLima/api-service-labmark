using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;
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
            dilutionSampleDto.Points= new List<PointDto>();
            dilutionSampleDto.Sample = AmostraMapToSampleDto.Map(new SampleDto(), diluicaoAmostra.fkAmostra);
            foreach (var x in diluicaoAmostra.Ponteiras)
            {
                var point = new PointDto((EnumPoints)x.Codigo);
                point.Value = (int) x.Valor;
                dilutionSampleDto.Points.Add(point);
            }
            foreach (var x in diluicaoAmostra.AguaDiluicaos)
            {
                var waterDilution = new WaterDilutionDto((EnumWaterDilution)x.Codigo);
                waterDilution.Value = (int) x.Valor;
                dilutionSampleDto.WaterDilutions.Add(waterDilution);
            }            


            return dilutionSampleDto;
        }

    }
}

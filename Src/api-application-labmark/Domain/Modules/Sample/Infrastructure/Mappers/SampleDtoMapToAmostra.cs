using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class SampleDtoMapToAmostra
    {
        public static Amostra Map(SampleDto sampleDto, Amostra amostra)
        {
            amostra.Id = sampleDto.Id;
            amostra.Descricao = sampleDto.Description;
            amostra.Lote = sampleDto.Lot;
            amostra.DataColeta = sampleDto.CollectionDate;
            amostra.DataFabricacao = sampleDto.FabricationDate;
            amostra.DataValidade = sampleDto.ExpirationDate;
            amostra.DataEmissao = sampleDto.ReceivingDate;
            amostra.Oficio = sampleDto.Calling;
            amostra.TAA = sampleDto.TAA;
            amostra.Lacre = sampleDto.Seal;
            amostra.Temperatura = sampleDto.Temperature;                 

            return amostra;
        }
    }
}

﻿using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class AmostraMapToSampleDto
    {
        public static SampleDto Map(SampleDto sampleDto, Amostra amostra)
        {
            sampleDto.Id = amostra.Id;
            sampleDto.Description = amostra.Descricao;
            sampleDto.Lot = amostra.Lote;
            sampleDto.CollectionDate = amostra.DataColeta;
            sampleDto.FabricationDate = amostra.DataFabricacao;
            sampleDto.ExpirationDate = amostra.DataValidade;
            sampleDto.ReceivingDate = amostra.DataEmissao;
            sampleDto.Calling = amostra.Oficio;
            sampleDto.TAA = amostra.TAA;
            sampleDto.Seal = amostra.Lacre;
            sampleDto.Temperature = amostra.Temperatura;
            
          

            return sampleDto;
        }



    }
}
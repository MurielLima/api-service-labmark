using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Mappers
{
    public class AssayDtoMapToEnsaio
    {
       
        public static Ensaio Map(Ensaio ensaio, AssayDto assayDto)
        {
            
            ensaio.Id = assayDto.Id;
            ensaio.Metodologia = assayDto.Methodology;
            ensaio.Referencia = assayDto.Reference;
            ensaio.Codigo = (int)assayDto.Code;
            ensaio.Descricao = assayDto.Description;
           


            return ensaio;
        }

       

    }
}

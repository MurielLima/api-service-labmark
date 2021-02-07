using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ContagemMBLBMapToCountMBLBDto
    {
        public static CountMBLBDto Map(CountMBLBDto countMBLBDto, ContagemMBLB contagemMBLB)
        {
            countMBLBDto.Id = contagemMBLB.Id;
            countMBLBDto.Result = contagemMBLB.Resultado;
            countMBLBDto.DateOfResult = contagemMBLB.DataResultado;
            countMBLBDto.Reading = contagemMBLB.Leitura;
            countMBLBDto.Dilution = contagemMBLB.Diluicao;

            return countMBLBDto;
        }


    }
}

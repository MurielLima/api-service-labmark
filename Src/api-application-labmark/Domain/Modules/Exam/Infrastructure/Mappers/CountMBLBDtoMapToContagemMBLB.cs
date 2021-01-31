using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class CountMBLBDtoMapToContagemMBLB
    {

        public static ContagemMBLB Map(ContagemMBLB contagemMBLB, CountMBLBDto countMBLBDto)
        {

            contagemMBLB.Id = countMBLBDto.Id;
            contagemMBLB.Resultado = countMBLBDto.Result;
            contagemMBLB.DataResultado = countMBLBDto.DateOfResult;
             


            return contagemMBLB;
        }




    }
}

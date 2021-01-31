﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ContagemMBLBMapToCountMBLBDto
    {
        public static CountMBLBDto Map(ContagemMBLB contagemMBLB, CountMBLBDto countMBLBDto)
        {
            countMBLBDto.Id = contagemMBLB.Id;
            countMBLBDto.Result = contagemMBLB.Resultado;
            countMBLBDto.DateOfResult = contagemMBLB.DataResultado;
            



            return countMBLBDto;
        }


    }
}

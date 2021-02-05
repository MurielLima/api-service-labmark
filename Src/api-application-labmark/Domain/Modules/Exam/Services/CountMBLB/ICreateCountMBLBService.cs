using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Services.CountMBLB
{
    public interface ICreateCountMBLBService
    {
        Task<CountMBLBDto> Execute(CountMBLBDto countMBLBDto, int? dilutionSampleId);
    }
}

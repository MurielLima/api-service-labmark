using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Services.CountMBLB;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Services.CountMBLB
{
    public class UpdateCountMBLBService : IUpdateCountMBLBService
    {
        public Task<IList<CountMBLBDto>> Execute(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

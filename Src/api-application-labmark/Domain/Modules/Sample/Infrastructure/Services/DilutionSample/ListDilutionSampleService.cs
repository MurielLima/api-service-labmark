using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.DilutionSample;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.DilutionSample
{
    public class ListDilutionSampleService : IListDilutionSampleService
    {

        public Task<IList<DilutionSampleDto>> Execute(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

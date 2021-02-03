using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.Sample;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample
{
    public class UpdateSampleService : IUpdateSampleService
    {
        public Task<SampleDto> Execute(SampleDto sampleDto)
        {
            throw new NotImplementedException();
        }
    }
}

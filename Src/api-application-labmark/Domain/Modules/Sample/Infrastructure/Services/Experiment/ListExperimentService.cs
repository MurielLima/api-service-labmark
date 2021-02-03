using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.Experiment;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Experiment
{
    public class ListExperimentService : IListExperimentService
    {
        public Task<ExperimentDto> Execute(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Incubation.Services;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Services
{
    public class UpdateIncubationService : IUpdateIncubationService
    {
        public Task<IncubationDto> Execute(IncubationDto incubationDto)
        {
            throw new NotImplementedException();
        }
    }
}

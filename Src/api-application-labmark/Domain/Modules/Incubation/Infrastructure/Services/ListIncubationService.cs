using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Incubation.Services;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Services
{
    public class ListIncubationService : IListIncubationService
    {
        public Task<IList<IncubationDto>> Execute(int? incubationId)
        {
            throw new NotImplementedException();
        }
    }
}

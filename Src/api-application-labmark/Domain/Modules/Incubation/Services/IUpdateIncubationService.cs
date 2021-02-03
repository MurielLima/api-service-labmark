using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Incubation.Services
{
    public interface IUpdateIncubationService
    {
        Task<IncubationDto> Execute(IncubationDto incubationDto);
    }
}

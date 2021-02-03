using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Incubation.Controllers
{
    public interface IIncubationController
    {
        public Task<IActionResult> Create([FromBody] IncubationDto incubationDto);
        public Task<IActionResult> Update([FromBody] IncubationDto incubationDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);
    }
}

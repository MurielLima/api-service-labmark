using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Controllers;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class IncubationController : ControllerBase, IIncubationController
    {
        public Task<IActionResult> Create([FromBody] IncubationDto incubationDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> List([FromRoute] int? solicitationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Update([FromBody] IncubationDto incubationDto)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class EscherichiaColiformsController : ControllerBase, IEscherichiaColiformsController
    {
        public Task<IActionResult> Create([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> List([FromRoute] int? solicitationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Update([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto)
        {
            throw new System.NotImplementedException();
        }
    }
}

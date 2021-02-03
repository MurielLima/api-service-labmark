using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CountMBLBController : ControllerBase, ICountMBLBController
    {
        public Task<IActionResult> Create([FromBody] CountMBLBDto countMBLB)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> List([FromRoute] int? solicitationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IActionResult> Update([FromBody] CountMBLBDto countMBLB)
        {
            throw new System.NotImplementedException();
        }
    }
}

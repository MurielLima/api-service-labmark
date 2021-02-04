using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Controllers
{
    public interface ISampleController
    {
        public Task<IActionResult> Create([FromBody] SampleDto sampleDto, int? solicitationId);
        public Task<IActionResult> Update([FromBody] SampleDto sampleDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);
    }
}
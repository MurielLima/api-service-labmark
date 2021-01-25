using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Controllers
{
    public interface IDilutionSampleController
    {
        public Task<IActionResult> Create([FromBody] DilutionSampleDto dilutionSampleDto);
        public Task<IActionResult> Update([FromBody] DilutionSampleDto dilutionSampleDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);
    }
}

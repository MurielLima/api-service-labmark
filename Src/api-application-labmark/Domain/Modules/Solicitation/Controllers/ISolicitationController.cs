using System.Threading.Tasks;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Controllers
{
    public interface ISolicitationController
    {
        public Task<IActionResult> Create([FromBody] SolicitationDto solicitationDto);
        public Task<IActionResult> Update([FromBody] SolicitationDto solicitationDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);

    }
}
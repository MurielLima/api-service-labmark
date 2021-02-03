using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Controllers
{
    public interface IEscherichiaColiformsController
    {
        public Task<IActionResult> Create([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto);
        public Task<IActionResult> Update([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);
    }
}

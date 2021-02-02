using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Services.EscherichiaColiforms;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class EscherichiaColiformsController : ControllerBase, IEscherichiaColiformsController
    {
        private readonly ICreateEscherichiaColiformsService _createEscherichiaColiformsService;
        private readonly IUpdateEscherichiaColiformsService _updateEscherichiaColiformsService;

        public EscherichiaColiformsController(IUpdateEscherichiaColiformsService updateEscherichiaColiformsService, ICreateEscherichiaColiformsService createEscherichiaColiformsService)
        {
            _updateEscherichiaColiformsService = updateEscherichiaColiformsService;
            _createEscherichiaColiformsService = createEscherichiaColiformsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto, int? sampleId)
        {
            escherichiaColiformsDto = await _createEscherichiaColiformsService.Execute(escherichiaColiformsDto, sampleId);
            return Ok(new ResponseDto("success", escherichiaColiformsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ColiformsEscherichiaDto escherichiaColiformsDto)
        {
            escherichiaColiformsDto = await _updateEscherichiaColiformsService.Execute(escherichiaColiformsDto);
            return Ok(new ResponseDto("success", escherichiaColiformsDto));
        }
    }
}

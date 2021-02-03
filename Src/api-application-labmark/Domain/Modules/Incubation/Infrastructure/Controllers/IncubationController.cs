using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Incubation.Controllers;
using Labmark.Domain.Modules.Incubation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Incubation.Services;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Incubation.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class IncubationController : ControllerBase, IIncubationController
    {
        private readonly ICreateIncubationService _createIncubationService;
        private readonly IListIncubationService _listIncubationService;
        private readonly IUpdateIncubationService _updateIncubationService;

        public IncubationController(ICreateIncubationService createIncubationService, IListIncubationService listIncubationService, IUpdateIncubationService updateIncubationService)
        {
            _createIncubationService = createIncubationService;
            _listIncubationService = listIncubationService;
            _updateIncubationService = updateIncubationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IncubationDto incubationDto)
        {
            incubationDto = await _createIncubationService.Execute(incubationDto);
            return Ok(new ResponseDto("success", incubationDto));
        }
        [HttpGet]
        public async Task<IActionResult> List([FromRoute] int? incubationId)
        {
            IList<IncubationDto> incubationDtos = await _listIncubationService.Execute(incubationId);
            return Ok(new ResponseDto("success", incubationDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] IncubationDto incubationDto)
        {
            incubationDto = await _updateIncubationService.Execute(incubationDto);
            return Ok(new ResponseDto("success", incubationDto));
        }
    }
}

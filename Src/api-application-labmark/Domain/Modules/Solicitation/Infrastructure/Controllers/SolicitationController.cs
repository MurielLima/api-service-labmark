using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Services;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class SolicitationController : ControllerBase, ISolicitationController
    {
        private readonly ICreateSolicitationService _createSolicitationService;
        private readonly IUpdateSolicitationService _updateSolicitationService;
        private readonly IListSolicitationService _listSolicitationService;

        public SolicitationController(IListSolicitationService listSolicitationService, IUpdateSolicitationService updateSolicitationService, ICreateSolicitationService createSolicitationService)
        {
            _listSolicitationService = listSolicitationService;
            _updateSolicitationService = updateSolicitationService;
            _createSolicitationService = createSolicitationService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SolicitationDto solicitationDto, int clientId)
        {
            solicitationDto = await _createSolicitationService.Execute(solicitationDto, clientId);
            return Ok(new ResponseDto("success", solicitationDto));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> List([FromRoute] int? solicitationId)
        {
            IList<SolicitationDto> solicitacionDtos = await _listSolicitationService.Execute(solicitationId);
            return Ok(new ResponseDto("success", solicitacionDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SolicitationDto solicitationDto)
        {
            solicitationDto = await _updateSolicitationService.Execute(solicitationDto);
            return Ok(new ResponseDto("success", solicitationDto));
        }
    }
}

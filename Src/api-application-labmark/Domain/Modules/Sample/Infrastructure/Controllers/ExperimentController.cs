using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.Experiment;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ExperimentController : ControllerBase, IExperimentController
    {
        private readonly ICreateExperimentService _createExperimentService;
        private readonly IListExperimentService _listExperimentService;
        private readonly IUpdateExperimentService _updateExperimentService;

        public ExperimentController(ICreateExperimentService createExperimentService, IListExperimentService listExperimentService, IUpdateExperimentService updateExperimentService)
        {
            _createExperimentService = createExperimentService;
            _listExperimentService = listExperimentService;
            _updateExperimentService = updateExperimentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ExperimentDto experimentDto)
        {
            experimentDto = await _createExperimentService.Execute(experimentDto);
            return Ok(new ResponseDto("success", experimentDto));
        }
        [HttpGet]
        public async Task<IActionResult> List([FromRoute] int? experimentId)
        {
            IList<ExperimentDto> experimentDtos = await _listExperimentService.Execute(experimentId);
            return Ok(new ResponseDto("success", experimentDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ExperimentDto experimentDto)
        {
            experimentDto = await _updateExperimentService.Execute(experimentDto);
            return Ok(new ResponseDto("success", experimentDto));
        }
    }
}

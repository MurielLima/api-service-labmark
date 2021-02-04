using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.DilutionSample;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DilutionSampleController : ControllerBase, IDilutionSampleController
    {
        private readonly ICreateDilutionSampleService _createDilutionSampleService;
        private readonly IListDilutionSampleService _listDilutionSampleService;
        private readonly IUpdateDilutionSampleService _updateDilutionSampleService;

        public DilutionSampleController(ICreateDilutionSampleService createDilutionSampleService, IListDilutionSampleService listDilutionSampleService, IUpdateDilutionSampleService updateDilutionSampleService)
        {
            _createDilutionSampleService = createDilutionSampleService;
            _listDilutionSampleService = listDilutionSampleService;
            _updateDilutionSampleService = updateDilutionSampleService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DilutionSampleDto DilutionSampleDto, int? sampleId)
        {
            DilutionSampleDto = await _createDilutionSampleService.Execute(DilutionSampleDto, sampleId);
            return Ok(new ResponseDto("success", DilutionSampleDto));
        }
        [HttpGet]
        public async Task<IActionResult> List([FromRoute] int? dilutionSampleId)
        {
            IList<DilutionSampleDto> dilutionSampleDtos = await _listDilutionSampleService.Execute(dilutionSampleId);
            return Ok(new ResponseDto("success", dilutionSampleDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DilutionSampleDto dilutionSampleDto)
        {
            dilutionSampleDto = await _updateDilutionSampleService.Execute(dilutionSampleDto);
            return Ok(new ResponseDto("success", dilutionSampleDto));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Services.Assay;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class SampleController : ControllerBase, ISampleController
    {
        private readonly ICreateSampleService _createSampleService;
        private readonly IListSampleService _listSampleService;
        private readonly IListAssaySampleDilutionService _listAssayBySampleDilutionService;
        private readonly IUpdateSampleService _updateSampleService;

        public SampleController(ICreateSampleService createSampleService, IListSampleService listSampleService, IUpdateSampleService updateSampleService, IListAssaySampleDilutionService listAssayBySampleDilutionService)
        {
            _createSampleService = createSampleService;
            _listSampleService = listSampleService;
            _updateSampleService = updateSampleService;
            _listAssayBySampleDilutionService = listAssayBySampleDilutionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SampleDto SampleDto, int? solicitationId)
        {
            SampleDto = await _createSampleService.Execute(SampleDto, solicitationId);
            return Ok(new ResponseDto("success", SampleDto));
        } 
        [HttpGet]
        public async Task<IActionResult> List([FromRoute] int? sampleId)
        {
            IList<SampleDto> sampleDtos = await _listSampleService.Execute(sampleId);
            return Ok(new ResponseDto("success", sampleDtos));
        }
        [HttpGet]
        public async Task<IActionResult> ListAssayBySample([FromRoute] int sampleDilutionId)
        {
            IList<AssayDto> assayDtos = await _listAssayBySampleDilutionService.Execute(sampleDilutionId);
            return Ok(new ResponseDto("success", assayDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SampleDto SampleDto)
        {
            SampleDto = await _updateSampleService.Execute(SampleDto);
            return Ok(new ResponseDto("success", SampleDto));
        }
    }
}

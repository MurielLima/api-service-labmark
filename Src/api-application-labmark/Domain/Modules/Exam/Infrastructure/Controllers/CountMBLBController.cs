using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Services.CountMBLB;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CountMBLBController : ControllerBase, ICountMBLBController
    {
        private readonly ICreateCountMBLBService _createCountMBLBService;
        private readonly IUpdateCountMBLBService _updateCountMBLBService;

        public CountMBLBController(ICreateCountMBLBService createCountMBLBService, IUpdateCountMBLBService updateCountMBLBService)
        {
            _createCountMBLBService = createCountMBLBService;
            _updateCountMBLBService = updateCountMBLBService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountMBLBDto countMBLB, int? sampleId)
        {
            countMBLB = await _createCountMBLBService.Execute(countMBLB, sampleId);
            return Ok(new ResponseDto("success", countMBLB));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int? id)
        {
            IList<CountMBLBDto> countMBLB = await _updateCountMBLBService.Execute(id);
            return Ok(new ResponseDto("success", countMBLB));
        }
    }
}

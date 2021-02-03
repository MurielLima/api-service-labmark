using System;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class SampleController : ControllerBase, ISampleController
    {
        [HttpPost]
        Task<IActionResult> ISampleController.Create(SampleDto sampleDto)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id:int}")]
        Task<IActionResult> ISampleController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        Task<IActionResult> ISampleController.Update(SampleDto sampleDto)
        {
            throw new NotImplementedException();
        }
    }
}

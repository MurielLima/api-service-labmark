using System;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ExperimentController : ControllerBase, IExperimentController
    {
        [HttpPost]
        Task<IActionResult> IExperimentController.Create(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id:int}")]
        Task<IActionResult> IExperimentController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        Task<IActionResult> IExperimentController.Update(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }
    }
}

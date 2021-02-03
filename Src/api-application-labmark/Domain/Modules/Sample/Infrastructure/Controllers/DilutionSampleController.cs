using System;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DilutionSampleController : IDilutionSampleController
    {
        [HttpPost]
        Task<IActionResult> IDilutionSampleController.Create(DilutionSampleDto dilutionSampleDto)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id:int}")]
        Task<IActionResult> IDilutionSampleController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }
        [HttpPut]
        Task<IActionResult> IDilutionSampleController.Update(DilutionSampleDto dilutionSampleDto)
        {
            throw new NotImplementedException();
        }
    }
}

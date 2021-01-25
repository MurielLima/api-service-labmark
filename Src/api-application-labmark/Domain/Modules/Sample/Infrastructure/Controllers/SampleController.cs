using System;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    public class SampleController : ISampleController
    {
        Task<IActionResult> ISampleController.Create(SampleDto sampleDto)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> ISampleController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> ISampleController.Update(SampleDto sampleDto)
        {
            throw new NotImplementedException();
        }
    }
}

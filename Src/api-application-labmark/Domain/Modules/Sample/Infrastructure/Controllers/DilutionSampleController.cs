using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    public class DilutionSampleController : IDilutionSampleController
    {
        Task<IActionResult> IDilutionSampleController.Create(DilutionSampleDto dilutionSampleDto)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IDilutionSampleController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IDilutionSampleController.Update(DilutionSampleDto dilutionSampleDto)
        {
            throw new NotImplementedException();
        }
    }
}

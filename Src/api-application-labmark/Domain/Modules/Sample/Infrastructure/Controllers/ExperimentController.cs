using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Controllers
{
    public class ExperimentController : IExperimentController
    {
        Task<IActionResult> IExperimentController.Create(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IExperimentController.List(int? solicitationId)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IExperimentController.Update(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }
    }
}

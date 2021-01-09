using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Sample.Controllers
{
    public interface IExperimentController
    {
        public Task<IActionResult> Create([FromBody] ExperimentDto experimentDto);
        public Task<IActionResult> Update([FromBody] ExperimentDto experimentDto);
        public Task<IActionResult> List([FromRoute] int? solicitationId);
    }
}

using System;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Controllers
{
    public class SolicitationController : ISolicitationController
    {
        public Task<IActionResult> Create([FromBody] SolicitationDto solicitationDto, int selectedClientId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> List([FromRoute] int? solicitationId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update([FromBody] SolicitationDto solicitationDto)
        {
            throw new NotImplementedException();
        }
    }
}

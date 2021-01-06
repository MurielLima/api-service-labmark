using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Labmark.Domain.Modules.Client.Controllers
{
    public interface IClientController
    {
        public Task<IActionResult> Create([FromBody] ClientDto clientDto);
        public Task<IActionResult> Update([FromBody] ClientDto clientDto);
    }
}

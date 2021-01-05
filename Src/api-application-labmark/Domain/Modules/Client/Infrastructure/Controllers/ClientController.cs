using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Client.Services;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Labmark.Domain.Modules.Client.Infrastructure.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ClientController : ControllerBase, IClientController
    {
        private readonly ILogger<IClientController> _logger;
        private readonly ICreateClientService _createClientService;

        public ClientController(ICreateClientService createClientService, ILogger<IClientController> logger)
        {
            _createClientService = createClientService;
            _logger = logger;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] ClientDto clientDto)
        {
            clientDto = await _createClientService.Execute(clientDto);
            return Ok(new ResponseDto("success", clientDto));
        }
    }
}

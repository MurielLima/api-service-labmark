using System.Collections.Generic;
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
        private readonly IUpdateClientService _updateClientService;
        private readonly IListClientService _listClientService;

        public ClientController(ICreateClientService createClientService, ILogger<IClientController> logger, IUpdateClientService updateClientService, IListClientService listClientService)
        {
            _createClientService = createClientService;
            _logger = logger;
            _updateClientService = updateClientService;
            _listClientService = listClientService;
        }
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] ClientDto clientDto)
        {
            clientDto = await _createClientService.Execute(clientDto);
            return Ok(new ResponseDto("success", clientDto));
        }
        [HttpPut]
        public virtual async Task<IActionResult> Update([FromBody] ClientDto clientDto)
        {
            clientDto = await _updateClientService.Execute(clientDto);
            return Ok(new ResponseDto("success", clientDto));
        }
        [HttpGet("{clientId:int?}")]
        public virtual async Task<IActionResult> List([FromRoute] int? clientId)
        {
            IList<ClientDto> clientDtos = await _listClientService.Execute(clientId);
            return Ok(new ResponseDto("success", clientDtos));
        }
    }
}

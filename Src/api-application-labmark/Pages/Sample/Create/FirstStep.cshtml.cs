using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Enums;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class FirstStepModel : PageModel
    {
        private readonly ISolicitationController _solicitationController;
        private readonly IClientController _clientController;
        public FirstStepModel(ISolicitationController solicitationController, IClientController clientController)
        {
            _solicitationController = solicitationController;
            _clientController = clientController;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ResponseDto responseDto = (ResponseDto) ((ObjectResult)(await _clientController.List(_selectedClientId))).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _solicitationController.Create(_solicitationDto, _selectedClientId);
            return Redirect($"/Sample/Create/SecondStep/?solicitationId={_solicitationDto.Id}");
        }
        [BindProperty]
        public IList<ClientDto> _clientDtos { get; set; }
        [BindProperty]
        public int _selectedClientId { get; set; }
        [BindProperty]
        public SolicitationDto _solicitationDto { get; set; }


    }
}

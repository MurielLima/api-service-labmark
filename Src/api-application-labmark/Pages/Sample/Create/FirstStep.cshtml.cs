using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class FirstStepModel : PageModel
    {
        private readonly ISolicitationController _solicitationController;
        public FirstStepModel(ISolicitationController solicitationController)
        {
            _solicitationController = solicitationController;
        }

        public IActionResult OnGet()
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)_solicitationController.List(_selectedClientId).Result).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            return Page();
        }
        public async Task<IActionResult> OnPost()
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

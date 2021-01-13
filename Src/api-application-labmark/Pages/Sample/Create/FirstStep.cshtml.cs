using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Enums;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labmark.Pages.Sample.Create
{
    public class FirstStepModel : PageModel
    {
        private readonly IClientController _clientController;
        public FirstStepModel(IClientController clientController)
        {
            _clientController = clientController;
        }

        public IActionResult OnGet()
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult) _clientController.List(_selectedClientId).Result).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            return Page();
        }
        public IActionResult OnPost()
        {
            _solicitationDto.AskDtos = new List<AskDto>();
            _packaged.Code = EnumQuestion.Packaged;
            _proccess.Code = EnumQuestion.Proccess;
            _temperature.Code = EnumQuestion.Temperature;
            _transport.Code = EnumQuestion.Transport;
            _volume.Code = EnumQuestion.Volume;
            _solicitationDto.AskDtos.Add(_packaged);
            _solicitationDto.AskDtos.Add(_proccess);
            _solicitationDto.AskDtos.Add(_volume);
            _solicitationDto.AskDtos.Add(_temperature);
            _solicitationDto.AskDtos.Add(_transport);
            return Redirect($"/Sample/SecondStep/?solicitationId={_solicitationDto.Id}");
        }
        [BindProperty]
        public IList<ClientDto> _clientDtos { get; set; }
        [BindProperty]
        public int _selectedClientId { get; set; }
        [BindProperty]
        public SolicitationDto _solicitationDto { get; set; }
        [BindProperty]
        public AskDto _packaged { get; set; }
        [BindProperty]
        public AskDto _proccess { get; set; }
        [BindProperty]
        public AskDto _temperature { get; set; }
        [BindProperty]
        public AskDto _transport { get; set; }
        [BindProperty]
        public AskDto _volume { get; set; }
    }
}

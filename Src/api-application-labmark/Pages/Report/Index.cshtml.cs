using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IClientController _clientController;
        public IndexModel(IClientController clientController)
        {
            _clientController = clientController;

        }

        [BindProperty]
        public IList<ClientDto> _clientDtos { get; set; }
        [BindProperty]
        public int _selectedClientId { get; set; }

        [BindProperty]
        public IList<SampleDto> _sampleDtos { get; set; }
        [BindProperty]
        public SampleDto _sampleDto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _clientController.List(_selectedClientId))).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            return Page();
        }
    }
}

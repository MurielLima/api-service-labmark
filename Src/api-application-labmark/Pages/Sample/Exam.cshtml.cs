using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample
{
    public class ExamModel : PageModel
    {
        [BindProperty]
        public int _sampleDilutionId { get; set; }
        [BindProperty]
        public string _sampleName { get; set; }

        [BindProperty]
        public string _sampleClient { get; set; }

        [BindProperty]
        public IList<ClientDto> _clientDtos { get; set; }

        private readonly IDilutionSampleController _dilutionSampleController;
        private readonly IClientController _clientController;

        public ExamModel(IDilutionSampleController dilutionSampleController, IClientController clientController)
        {
            _dilutionSampleController = dilutionSampleController;
            _clientController = clientController;
        }

        public async Task<IActionResult> OnGetAsync(int sampleDilutionId)
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleDilutionId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;      

            _sampleName = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Id} - {_dilutionSampleDtos.FirstOrDefault().Sample.Description}";
            _sampleClient = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Client.Name}";
            _sampleDilutionId = sampleDilutionId;
            return Page();
        }
    }
}

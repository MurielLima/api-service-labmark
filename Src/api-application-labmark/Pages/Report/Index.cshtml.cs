using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.ReportSample.Controllers;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IClientController _clientController;
        private readonly ISampleController _sampleController;
        private readonly IReportController _reportController;
        public IndexModel(IClientController clientController, ISampleController sampleController, IReportController reportController)
        {
            _clientController = clientController;
            _sampleController = sampleController;
            _reportController = reportController;
        }

        [BindProperty]
        public IList<ClientDto> _clientDtos { get; set; }
        [BindProperty]
        public int _selectedClientId { get; set; }
        [BindProperty]
        public int _selectedSampleId { get; set; }
        [BindProperty]
        public IList<SampleDto> _sampleDtos { get; set; }
        [BindProperty]
        public SampleDto _sampleDto { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _clientController.List(0))).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _clientController.List(0))).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
             responseDto = (ResponseDto)((ObjectResult)(await _sampleController.ListByClient(_selectedClientId))).Value;
            _sampleDtos = (List<SampleDto>)responseDto.detail;
            _sampleDto = _sampleDtos.FirstOrDefault(x => x.Id == _selectedSampleId);
            return Page();
        }
        
        public async Task<IActionResult> OnPostGenerate()
        {
            var query = new ReportDto();
            query.AmostraId = _selectedSampleId;
            int count = _sampleDto.Assays.Count(x=> x.Value);
            var assays = _sampleDto.Assays.Where(x => x.Value).ToList();
            query.Ensaios = new int[count];
            for (int i =0; i< count; i++)
            {
                query.Ensaios[i] = assays[i].Id;
            }
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _clientController.List(0))).Value;
            _clientDtos = (List<ClientDto>)responseDto.detail;
            responseDto = (ResponseDto)((ObjectResult)(await _sampleController.ListByClient(_selectedClientId))).Value;
            _sampleDtos = (List<SampleDto>)responseDto.detail;
            _sampleDto = _sampleDtos.FirstOrDefault(x => x.Id == _selectedSampleId);
            if(query.Ensaios.Length > 0)
                return _reportController.Generate(query);
            return Page();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
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
        private readonly IDilutionSampleController _dilutionSampleController;

        public ExamModel(IDilutionSampleController dilutionSampleController)
        {
            _dilutionSampleController = dilutionSampleController;
        }

        public async Task<IActionResult> OnGetAsync(int sampleDilutionId)
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleDilutionId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;
            _sampleName = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Id} : {_dilutionSampleDtos.FirstOrDefault().Sample.Description}";
            _sampleDilutionId = sampleDilutionId;
            return Page();
        }
    }
}

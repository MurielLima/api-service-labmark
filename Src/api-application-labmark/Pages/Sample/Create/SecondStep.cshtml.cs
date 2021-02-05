using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class SecondStepModel : PageModel
    {
        private readonly ISampleController _sampleController;

        public SecondStepModel(ISampleController sampleController)
        {
            _sampleController = sampleController;
        }
        public IActionResult OnGet()
        {
            _sampleDto = new SampleDto();
            _sampleDto.Assays = new List<AssayDto>();
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M02, 1));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M06, 2));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M07, 3));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M13, 4));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M15, 5));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M15L, 6));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M16, 7));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M16L, 8));
            return Page();
        }
        public async Task<IActionResult> OnPost(int solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicitação válida!");
            }
            _sampleDto.Assays = _sampleDto.Assays.Where(x => x.Value).ToList();
            await _sampleController.Create(_sampleDto, solicitationId);
            return Redirect($"/Exam/SampleDilution/FirstStep/?sampleId={_sampleDto.Id}");
        }

        [BindProperty]
        public SampleDto _sampleDto { get; set; }

    }
}

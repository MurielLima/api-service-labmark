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
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M02, 2));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M06, 4));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M07, 5));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M13, 8));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M15, 10));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M15L, 11));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M16, 12));
           _sampleDto.Assays.Add(new AssayDto(EnumAssay.M16L, 13));
            return Page();
        }
        public async Task<IActionResult> OnPost(int solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicita��o v�lida!");
            }
            _sampleDto.Assays = _sampleDto.Assays.Where(x => x.Value).ToList();
            await _sampleController.Create(_sampleDto, solicitationId);
            return Redirect($"/Exam/SampleDilution/FirstStep/?sampleId={_sampleDto.Id}");
        }

        [BindProperty]
        public SampleDto _sampleDto { get; set; }

    }
}

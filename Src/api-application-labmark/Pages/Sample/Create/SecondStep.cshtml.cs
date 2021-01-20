using System.Collections.Generic;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class SecondStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            _sampleDtos = new SampleDto();
            _sampleDtos.Assays = new List<AssayDto>();
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M02));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M06));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M07));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M13));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M15));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M15L));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M16));
            _sampleDtos.Assays.Add(new AssayDto(EnumAssay.M16L));

            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }

        [BindProperty]
        public SampleDto _sampleDtos { get; set; }

    }
}

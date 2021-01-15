using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Labmark.Pages.Sample.Create
{
    public class SecondStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            _sampleDtos.Assays = new List<AssayDto>();
            _m02.Code = EnumAssay.M02;
            _m06.Code = EnumAssay.M06;
            _m07.Code = EnumAssay.M07;
            _m13.Code = EnumAssay.M13;
            _m15.Code = EnumAssay.M15;
            _m15L.Code = EnumAssay.M15L;
            _m16.Code = EnumAssay.M16;
            _m16L.Code = EnumAssay.M16L;
            _sampleDtos.Assays.Add(_m02);
            _sampleDtos.Assays.Add(_m06);
            _sampleDtos.Assays.Add(_m07);
            _sampleDtos.Assays.Add(_m13);
            _sampleDtos.Assays.Add(_m15);
            _sampleDtos.Assays.Add(_m15L);
            _sampleDtos.Assays.Add(_m16);
            _sampleDtos.Assays.Add(_m16L);
            return null;
        }

        [BindProperty]
        public SampleDto _sampleDtos { get; set; }
        [BindProperty]
        public AssayDto _m02 { get; set; }
        [BindProperty]
        public AssayDto _m06 { get; set; }
        [BindProperty]
        public AssayDto _m07 { get; set; }
        [BindProperty]
        public AssayDto _m13 { get; set; }
        [BindProperty]
        public AssayDto _m15 { get; set; }
        [BindProperty]
        public AssayDto _m15L { get; set; }
        [BindProperty]
        public AssayDto _m16 { get; set; }
        [BindProperty]
        public AssayDto _m16L { get; set; }

    }
}

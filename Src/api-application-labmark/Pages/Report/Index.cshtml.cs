using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Report
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IList<SampleDto> _sampleDtos { get; set; }
        [BindProperty]
        public SampleDto _sampleDto { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

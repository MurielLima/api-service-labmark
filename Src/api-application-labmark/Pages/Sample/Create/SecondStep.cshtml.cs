using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            return Page();
        }

        [BindProperty]
        public SampleDto _sampleDtos { get; set; }

    }
}

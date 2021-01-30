using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class SecondStepModel : PageModel
    {
        [BindProperty]
        public int _selectedDilutionId { get; set; }


        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

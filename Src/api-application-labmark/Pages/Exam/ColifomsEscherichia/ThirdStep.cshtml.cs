using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class ThirdStepModel : PageModel
    {
        [BindProperty]
        public ColifomsEscherichiaDto _colifomsEscherichia { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

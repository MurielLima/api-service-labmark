using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample
{
    public class ExamModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

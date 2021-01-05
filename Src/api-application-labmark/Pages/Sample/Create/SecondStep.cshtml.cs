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
    }
}

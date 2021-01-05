using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class FirstStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

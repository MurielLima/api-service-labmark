using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Shared
{
    public class NotFoundModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

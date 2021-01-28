using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Incubation
{
    public class IndexModel : PageModel
    {
        
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

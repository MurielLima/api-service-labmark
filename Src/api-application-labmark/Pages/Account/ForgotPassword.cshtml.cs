using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

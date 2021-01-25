using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Test.CountMBLB
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CountMBLBDto _contagemMBLB { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

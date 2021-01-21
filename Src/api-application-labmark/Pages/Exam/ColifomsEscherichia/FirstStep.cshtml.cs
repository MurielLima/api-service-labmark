using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public ColifomsEscherichiaDto _colifomsEscherichia { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

       
    }
}

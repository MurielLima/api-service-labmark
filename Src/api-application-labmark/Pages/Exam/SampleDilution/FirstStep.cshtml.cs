using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Test.SampleDilution
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }
        
        [BindProperty]
        public int _selectedLocalId { get; set; }

     
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

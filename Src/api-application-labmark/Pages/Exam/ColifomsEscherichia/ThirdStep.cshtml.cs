using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class ThirdStepModel : PageModel
    {
        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }

        [BindProperty]
        public IList<ReadingDto> _leituras { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}

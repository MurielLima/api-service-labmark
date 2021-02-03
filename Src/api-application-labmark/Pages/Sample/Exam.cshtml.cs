using System.Collections.Generic;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample
{
    public class ExamModel : PageModel
    {
        [BindProperty]
        public int _sampleDilutionId { get; set; }
        public IActionResult OnGet(int sampleDilutionId)
        {
            _sampleDilutionId = sampleDilutionId;
            return Page();
        }
    }
}

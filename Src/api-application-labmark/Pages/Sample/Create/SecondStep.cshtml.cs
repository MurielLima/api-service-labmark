using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
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
        public IActionResult OnPost(int solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicitação válida!");
            }
            return Page();
        }

        [BindProperty]
        public SampleDto _sampleDto { get; set; }

    }
}

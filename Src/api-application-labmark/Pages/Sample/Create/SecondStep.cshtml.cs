using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Sample.Create
{
    public class SecondStepModel : PageModel
    {
        private readonly ISampleController _sampleController;

        public SecondStepModel(ISampleController sampleController)
        {
            _sampleController = sampleController;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(int solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicitação válida!");
            }
            await _sampleController.Create(_sampleDto, solicitationId);
            return Redirect($"/Exam/SampleDilution/FirstStep/?sampleId={_sampleDto.Id}");
        }

        [BindProperty]
        public SampleDto _sampleDto { get; set; }

    }
}

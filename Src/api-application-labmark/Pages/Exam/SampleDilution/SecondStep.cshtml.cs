using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.SampleDilution
{
    public class SecondStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }


        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }

        private readonly DilutionSampleController _dilutionSampleController;

        public SecondStepModel(DilutionSampleController dilutionSampleController)
        {
            _dilutionSampleController = dilutionSampleController;
        }


        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _dilutionSampleController.Update(_dilutionSampleDto);

            return Page();
        }


    }
}

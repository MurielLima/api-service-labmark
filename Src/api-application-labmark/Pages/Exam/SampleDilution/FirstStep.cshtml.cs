using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

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



        private readonly DilutionSampleController _dilutionSampleController;

        public FirstStepModel(DilutionSampleController dilutionSampleController)
        {
            _dilutionSampleController = dilutionSampleController;
        }


        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _dilutionSampleController.Create(_dilutionSampleDto, sampleId);

            return Page();
        }

    }
}

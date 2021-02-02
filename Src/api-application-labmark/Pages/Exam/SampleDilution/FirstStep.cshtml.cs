using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Labmark.Pages.Exam.SampleDilution
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }
        
        [BindProperty]
        public int _selectedLocalId { get; set; }
        [BindProperty]
        public char _typePipete { get; set; }
        [BindProperty]
        public int? _valuePipete { get; set; }



        public IActionResult OnGet()
        {
            return Page();
        }



        private readonly IDilutionSampleController _dilutionSampleController;

        public FirstStepModel(IDilutionSampleController dilutionSampleController)
        {
            _dilutionSampleController = dilutionSampleController;
        }


        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(_typePipete == 'M')
            {
                _dilutionSampleDto.Micropipette = _valuePipete;
            }
            else
            {
                _dilutionSampleDto.Pipette = _valuePipete;
            }
            await _dilutionSampleController.Create(_dilutionSampleDto, sampleId);

            return Redirect($"/Exam/SampleDilution/SecondStep/?sampleDilutionId={_dilutionSampleDto.Id}");
        }

    }
}

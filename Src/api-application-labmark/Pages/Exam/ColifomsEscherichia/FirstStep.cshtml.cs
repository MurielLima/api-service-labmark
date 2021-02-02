using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }

        [BindProperty]
        public IList<ReadingDto> _leituras { get; set; }

        [BindProperty]

        public IList<DilutionDto> _diluicoes { get; set; }


        private readonly IEscherichiaColiformsController _escherichiaColiformsController;

        public FirstStepModel(IEscherichiaColiformsController colifomsEscherichiaController)
        {
            _escherichiaColiformsController = colifomsEscherichiaController;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _escherichiaColiformsController.Create(_colifomsEscherichia, sampleId);

            return Redirect($"/Exam/ColifomsEscherichia/SecondStep/?_colifomsEscherichiaId={_colifomsEscherichia.Id}");
        }


    }
}

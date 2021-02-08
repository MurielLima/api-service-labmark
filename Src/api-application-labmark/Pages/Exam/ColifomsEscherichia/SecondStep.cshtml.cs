using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Infrastructure.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using System.Collections.Generic;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Domain.Modules.Sample.Controllers;
using System.Linq;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class SecondStepModel : PageModel
    {


        [BindProperty]
        public int _selectedDilutionId { get; set; }


        [BindProperty]
        public IList<WaterDilutionDto> _waterDilutionDto { get; set; }

       

        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int colifomsEscherichiaId, int sampleId)
        {

            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> dilutionSampleDto = (List<DilutionSampleDto>)responseDto.detail;


            _waterDilutionDto = dilutionSampleDto.FirstOrDefault().WaterDilutions;
            return Page();
        }

        private readonly IEscherichiaColiformsController _escherichiaColiformsController;
        private readonly IDilutionSampleController _dilutionSampleController;



        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }

        public SecondStepModel(IEscherichiaColiformsController colifomsEscherichiaController, IDilutionSampleController dilutionSampleController)
        {
            _escherichiaColiformsController = colifomsEscherichiaController;
            _dilutionSampleController = dilutionSampleController;
        }

        public async Task<IActionResult> OnPostAsync(int colifomsEscherichiaId)
        {
            _colifomsEscherichia.Id = colifomsEscherichiaId;
            await _escherichiaColiformsController.Update(_colifomsEscherichia);

            return Redirect($"/Exam/ColifomsEscherichia/ThirdStep/?colifomsEscherichiaId={_colifomsEscherichia.Id}");
        }
    }
}

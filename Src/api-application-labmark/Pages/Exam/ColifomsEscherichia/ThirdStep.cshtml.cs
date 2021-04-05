using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class ThirdStepModel : PageModel
    {
        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }
        [BindProperty]
        public string _sampleName { get; set; }
        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }

    

        [BindProperty]
        public string _sampleClient { get; set; }

        public async Task<IActionResult> OnGetAsync(int colifomsEscherichiaId, int sampleId)
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> dilutionSampleDto = (List<DilutionSampleDto>)responseDto.detail;

            _sampleName = $"{dilutionSampleDto.FirstOrDefault().Sample.Id} - {dilutionSampleDto.FirstOrDefault().Sample.Description}";
            _sampleClient = $"{dilutionSampleDto.FirstOrDefault().Sample.Client.Name}";

         

            return Page();
        }

        private readonly IDilutionSampleController _dilutionSampleController;
        private readonly IEscherichiaColiformsController _escherichiaColiformsController;

        public ThirdStepModel(IEscherichiaColiformsController colifomsEscherichiaController, IDilutionSampleController dilutionSampleController)
        {
            _escherichiaColiformsController = colifomsEscherichiaController;
            _dilutionSampleController = dilutionSampleController;
        }

        public async Task<IActionResult> OnPostAsync(int colifomsEscherichiaId, int sampleId)
        {
            Alert alert = new Alert(AlertType.success);


            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> dilutionSampleDto = (List<DilutionSampleDto>)responseDto.detail;

            _sampleName = $"{dilutionSampleDto.FirstOrDefault().Sample.Id} - {dilutionSampleDto.FirstOrDefault().Sample.Description}";
            _sampleClient = $"{dilutionSampleDto.FirstOrDefault().Sample.Client.Name}";


            _colifomsEscherichia.Id = colifomsEscherichiaId;
            await _escherichiaColiformsController.Update(_colifomsEscherichia);
            alert.Text = "Coliformes criado com sucesso!";
            alert.ShowAlert(PageContext);
            return Page();
        }
    }
}

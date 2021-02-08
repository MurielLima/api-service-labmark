using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }

        [BindProperty]
        public int _selectedAssayId { get; set; }

        [BindProperty]
        public IList<AssayDto> _assaysDto { get; set; }
        [BindProperty]
        public IList<AssayDto> _assaysDtoAux { get; set; }


        private readonly IDilutionSampleController _dilutionSampleController;
        private readonly IEscherichiaColiformsController _escherichiaColiformsController;

        public FirstStepModel(IEscherichiaColiformsController colifomsEscherichiaController, IDilutionSampleController dilutionSampleController)
        {
            _escherichiaColiformsController = colifomsEscherichiaController;
            _dilutionSampleController = dilutionSampleController;
        }


        public async Task<IActionResult> OnGetAsync(int sampleId)
        {
            _colifomsEscherichia = new ColiformsEscherichiaDto();
            _colifomsEscherichia.dilutionColiformsEscherichiaDto = new List<DilutionColiformsEscherichiaDto>();
            _colifomsEscherichia.dilutionColiformsEscherichiaDto.Add(new DilutionColiformsEscherichiaDto(EnumReadings.FirstReading));
            _colifomsEscherichia.dilutionColiformsEscherichiaDto.Add(new DilutionColiformsEscherichiaDto(EnumReadings.SecondReading));

            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;

            _assaysDto = _dilutionSampleDtos.FirstOrDefault().Sample.Assays.Where(x => x.Code == EnumAssay.M06 || x.Code == EnumAssay.M07 || x.Code == EnumAssay.M15 || x.Code == EnumAssay.M15L || x.Code == EnumAssay.M16 || x.Code == EnumAssay.M16L).ToList();
            



            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {
         
            _colifomsEscherichia = new ColiformsEscherichiaDto();
            _colifomsEscherichia.dilutionColiformsEscherichiaDto = new List<DilutionColiformsEscherichiaDto>();
            _colifomsEscherichia.dilutionColiformsEscherichiaDto.Add(new DilutionColiformsEscherichiaDto(EnumReadings.FirstReading));
            _colifomsEscherichia.dilutionColiformsEscherichiaDto.Add(new DilutionColiformsEscherichiaDto(EnumReadings.SecondReading));

            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;

            _assaysDto = _dilutionSampleDtos.FirstOrDefault().Sample.Assays.Where(x => x.Code == EnumAssay.M06 || x.Code == EnumAssay.M07 || x.Code == EnumAssay.M15 || x.Code == EnumAssay.M15L || x.Code == EnumAssay.M16 || x.Code == EnumAssay.M16L).ToList();

           

            Alert alert = new Alert(AlertType.success);

            if (_selectedAssayId <= 0)
            {
                alert = new Alert(AlertType.warning);
                alert.Text = "Selecione um ensaio!";
                alert.ShowAlert(PageContext);
                return Page();

            }


            _colifomsEscherichia.AssayId = _selectedAssayId;
            await _escherichiaColiformsController.Create(_colifomsEscherichia, sampleId);
           

            return Redirect($"/Exam/ColifomsEscherichia/SecondStep/?colifomsEscherichiaId={_colifomsEscherichia.Id}");
        }


    }
}

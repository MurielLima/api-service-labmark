using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;
using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labmark.Pages.Exam.SampleDilution
{
    public class FirstStepModel : PageModel
    {
        [BindProperty]
        public DilutionSampleDto _dilutionSampleDto { get; set; }
        [BindProperty]
        public IList<LocationDto> _locations { get; set; }

        [BindProperty]
        public int _selectedLocal { get; set; }
        [BindProperty]
        public char _typePipete { get; set; }
        [BindProperty]
        public int? _valuePipete { get; set; }



        public IActionResult OnGet()
        {
            _dilutionSampleDto = new DilutionSampleDto();
            _dilutionSampleDto.Points = new List<PointDto>();
            _dilutionSampleDto.Points.Add(new PointDto(EnumPoints.P1));
            _dilutionSampleDto.Points.Add(new PointDto(EnumPoints.P2));
            _dilutionSampleDto.Points.Add(new PointDto(EnumPoints.P3));
            _locations = new List<LocationDto>();
            _locations.Add(new LocationDto(EnumLocal.Casa));
            _locations.Add(new LocationDto(EnumLocal.Cozinha));
            _locations.Add(new LocationDto(EnumLocal.Lavanderia));
            _dilutionSampleDto.WaterDilutions = new List<WaterDilutionDto>();
            _dilutionSampleDto.WaterDilutions.Add(new WaterDilutionDto(EnumWaterDilution.ML225));
            _dilutionSampleDto.WaterDilutions.Add(new WaterDilutionDto(EnumWaterDilution.ML9));
            return Page();
        }



        private readonly IDilutionSampleController _dilutionSampleController;

        public FirstStepModel(IDilutionSampleController dilutionSampleController)
        {
            _dilutionSampleController = dilutionSampleController;
        }


        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {
            if(_typePipete == 'M')
            {
                _dilutionSampleDto.Micropipette = _valuePipete;
            }
            else
            {
                _dilutionSampleDto.Pipette = _valuePipete;
            }
            _dilutionSampleDto.Location = new LocationDto((EnumLocal)_selectedLocal);
            await _dilutionSampleController.Create(_dilutionSampleDto, sampleId);

            return Redirect($"/Exam/SampleDilution/SecondStep/?sampleDilutionId={_dilutionSampleDto.Id}");
        }

    }
}

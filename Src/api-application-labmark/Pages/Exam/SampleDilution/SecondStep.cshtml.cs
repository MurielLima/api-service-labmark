using Labmark.Domain.Modules.Sample.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Controllers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labmark.Pages.Exam.SampleDilution
{
    public class SecondStepModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(int? sampleDilutionId)
        {
            if (sampleDilutionId > 0)
            {
                _experiments = new List<ExperimentDto>();
                ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _experimentController.List(0, sampleDilutionId))).Value;
                foreach (ExperimentDto experimentDto in ((List<ExperimentDto>)responseDto.detail))
                {
                    _experiments.Add(experimentDto);
                }
            }
            return Page();
        }


        [BindProperty]
        public ExperimentDto _experimentDto { get; set; }
        [BindProperty]
        public IList<ExperimentDto> _experiments { get; set; }

        private readonly IExperimentController _experimentController;

        public SecondStepModel(IExperimentController experimentController)
        {
            _experimentController = experimentController;
        }


        public async Task<IActionResult> OnPostAsync(int? sampleDilutionId)
        {
            await _experimentController.Create(_experimentDto, sampleDilutionId);
            _experiments = new List<ExperimentDto>();

            if (sampleDilutionId > 0)
            {
                ResponseDto responseDto = (ResponseDto)((ObjectResult)_experimentController.List(0, sampleDilutionId).Result).Value;
                foreach (ExperimentDto experimentDto in ((List<ExperimentDto>)responseDto.detail))
                {
                    _experiments.Add(experimentDto);
                }
            }
            return Page();
        }


    }
}

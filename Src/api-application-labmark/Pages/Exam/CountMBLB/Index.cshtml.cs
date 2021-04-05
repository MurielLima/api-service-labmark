using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
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

namespace Labmark.Pages.Test.CountMBLB
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CountMBLBDto _contagemMBLB { get; set; }

        [BindProperty]
        public int _selectedAssayId { get; set; }

        [BindProperty]
        public IList<AssayDto> _assaysDto { get; set; }

        [BindProperty]
        public string _sampleName { get; set; }

        [BindProperty]
        public string _sampleClient { get; set; }
        public async Task<IActionResult> OnGetAsync(int sampleId)
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;

            _assaysDto = _dilutionSampleDtos.FirstOrDefault().Sample.Assays.Where(x => x.Code == EnumAssay.M02 || x.Code == EnumAssay.M13).ToList();
            _sampleName = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Id} - {_dilutionSampleDtos.FirstOrDefault().Sample.Description}";
            _sampleClient = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Client.Name}";
            return Page();
        }

        private readonly ICountMBLBController _countMBLBController;
        private readonly IDilutionSampleController _dilutionSampleController;

        public IndexModel(ICountMBLBController countMBLBController, IDilutionSampleController dilutionSampleController)
        {
            _countMBLBController = countMBLBController;
            _dilutionSampleController = dilutionSampleController;
        }

        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {
            ResponseDto responseDto = (ResponseDto)((ObjectResult)(await _dilutionSampleController.List(sampleId))).Value;
            IList<DilutionSampleDto> _dilutionSampleDtos = (List<DilutionSampleDto>)responseDto.detail;

            _assaysDto = _dilutionSampleDtos.FirstOrDefault().Sample.Assays.Where(x => x.Code == EnumAssay.M02 || x.Code == EnumAssay.M13).ToList();
            Alert alert = new Alert(AlertType.success);
            _sampleName = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Id} - {_dilutionSampleDtos.FirstOrDefault().Sample.Description}";
            _sampleClient = $"{_dilutionSampleDtos.FirstOrDefault().Sample.Client.Name}";
            if (_selectedAssayId <= 0)
            {
                alert = new Alert(AlertType.warning);
                alert.Text = "Selecione um ensaio!";
                alert.ShowAlert(PageContext);
                return Page();
            }
            _contagemMBLB.AssayId = _selectedAssayId;
            await _countMBLBController.Create(_contagemMBLB, sampleId);
            alert.Text = "Contagem MBLB criado com sucesso!";
            alert.ShowAlert(PageContext);
            return Page();
        }



    }
}

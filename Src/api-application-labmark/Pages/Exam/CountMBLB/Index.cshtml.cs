using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.CountMBLB
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public CountMBLBDto _contagemMBLB { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        private readonly ICountMBLBController _countMBLBController;

        public IndexModel(ICountMBLBController countMBLBController)
        {
            _countMBLBController = countMBLBController;
        }

        public async Task<IActionResult> OnPostAsync(int? sampleId)
        {
            Alert alert = new Alert(AlertType.success);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _countMBLBController.Create(_contagemMBLB, sampleId);
            alert.Text = "Contagem MBLB criado com sucesso!";
            alert.ShowAlert(PageContext);
            return Page();
        }



    }
}

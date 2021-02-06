using Labmark.Domain.Modules.Exam.Controllers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class ThirdStepModel : PageModel
    {
        [BindProperty]
        public ColiformsEscherichiaDto _colifomsEscherichia { get; set; }

        [BindProperty]
        public IList<ReadingDto> _leituras { get; set; }
        public async Task<IActionResult> OnGetAsync(int? _colifomsEscherichiaId)
        {
            return Page();
        }

        private readonly IEscherichiaColiformsController _escherichiaColiformsController;

        public ThirdStepModel(IEscherichiaColiformsController colifomsEscherichiaController)
        {
            _escherichiaColiformsController = colifomsEscherichiaController;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Alert alert = new Alert(AlertType.success);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _escherichiaColiformsController.Update(_colifomsEscherichia);
            alert.Text = "Coliformes criado com sucesso!";
            alert.ShowAlert(PageContext);
            return Page();
        }
    }
}

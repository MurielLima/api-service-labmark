using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly IClientController _clientController;
        public CreateModel(IClientController clientController)
        {
            _clientController = clientController;
        }
        [BindProperty]
        public ClientDto _client { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Alert alert = new Alert(AlertType.success);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _clientController.Create(_client);
            alert.Text = "Cliente criado com sucesso!";
            alert.ShowAlert(PageContext);

            return Page();
        }
    }
}

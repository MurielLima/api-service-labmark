using System.Collections.Generic;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Controllers;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Client
{
    public class EditModel : PageModel
    {
        private readonly IClientController _clientController;
        public EditModel(IClientController clientController)
        {
            _clientController = clientController;
        }
        [BindProperty]
        public ClientDto _clientDto { get; set; }
        [BindProperty]
        public PhoneDto _phone { get; set; }
        public IActionResult OnGet(int id)
        {
            if (id > 0)
            {
                ResponseDto responseDto = (ResponseDto)((ObjectResult)_clientController.List(id).Result).Value;
                foreach (ClientDto clientDto in ((List<ClientDto>)responseDto.detail))
                {
                    _clientDto = clientDto;
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Alert alert = new Alert(AlertType.success);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (id > 0)
            {
                _clientDto.Id = id;
                await _clientController.Update(_clientDto);
                alert.Text = "Cliente criado com sucesso!";
            }
            else
            {
                alert = new Alert(AlertType.error);
                alert.Text = "Não foi possível alterar o cliente.";
            }
            alert.ShowAlert(PageContext);

            return Page();
        }
    }
}

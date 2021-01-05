using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountController _accountController;
        public RegisterModel(IAccountController accountController)
        {
            _accountController = accountController;
        }
        [BindProperty]
        public UserDto _people { get; set; }
        public async Task<IActionResult> OnGetAsync()
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
            await _accountController.Register(_people);
            alert.Text = "Usuário criado com sucesso!";
            alert.ShowAlert(PageContext);

            return Page();
        }
    }
}

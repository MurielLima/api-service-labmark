using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IAccountController _accountController;
        public LoginModel(IAccountController accountController)
        {
            _accountController = accountController;
        }
        [BindProperty]
        public UserLoginDto _user { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) 
            {
                return Page(); 
            }
            await _accountController.Login(_user);
            return Redirect("/");
        }
    }
}

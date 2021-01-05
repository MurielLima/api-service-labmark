using Labmark.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IAccountController _accountController;

        public LogoutModel(IAccountController accountController)
        {
            _accountController = accountController;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _accountController.Logout();
            return Redirect("/Account/Login");
        }
    }
}

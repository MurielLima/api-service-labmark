using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Microsoft.AspNetCore.Identity;
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

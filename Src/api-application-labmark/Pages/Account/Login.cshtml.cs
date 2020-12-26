using System;
using System.Collections.Generic;
using System.Linq;
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
        public UserDto _user { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                await _accountController.Login(_user);

            }
            catch
            {
               
            }




             return Page();

        }
    }
}

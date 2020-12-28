using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
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
            await _accountController.Register(_people);
            return Redirect("/Account/Index");
        }
    }
}

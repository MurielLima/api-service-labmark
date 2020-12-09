using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;

namespace Labmark.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        public IndexModel(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("/Account/Login");
            }
            return Page();
        }
    }
}

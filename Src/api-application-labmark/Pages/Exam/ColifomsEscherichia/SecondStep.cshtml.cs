using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Test.ColifomsEscherichia
{
    public class SecondStepModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
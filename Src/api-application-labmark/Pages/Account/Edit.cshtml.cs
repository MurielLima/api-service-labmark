using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Controllers;
using Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos;
using Labmark.Domain.Shared.Models.Dtos;
using Labmark.Pages.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labmark.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly IAccountController _accountController;
        public EditModel(IAccountController accountController)
        {
            _accountController = accountController;
        }
        [BindProperty]
        public UserDto _people { get; set; }
        public async Task<IActionResult> OnGetAsync(int edit)
        {
            if (edit > 0)
            {
                ResponseDto responseDto = (ResponseDto)((ObjectResult)_accountController.List(edit).Result).Value;
                foreach (EmployeeDto employeeDto in ((List<EmployeeDto>)responseDto.detail))
                {
                    _people = new UserDto
                    {
                        Id = employeeDto.Id,
                        Cep = employeeDto.Cep,
                        Mail = employeeDto.Mail,
                        Name = employeeDto.Name,
                        Neighborhood = employeeDto.Neighborhood,
                        Number = employeeDto.Number,
                        Phone = employeeDto.Phone,
                        Street = employeeDto.Street
                    };
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int edit)
        {
            Alert alert = new Alert(AlertType.success);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (edit > 0)
            {
                await _accountController.Update(_people);
                alert.Text = "Usuário alterado com sucesso!";
            }
            alert.ShowAlert(PageContext);

            return Page();
        }
    }
}

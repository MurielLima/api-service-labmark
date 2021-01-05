using System.Collections.Generic;
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
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id > 0)
            {
                ResponseDto responseDto = (ResponseDto)((ObjectResult)_accountController.List(id).Result).Value;
                foreach (EmployeeDto employeeDto in ((List<EmployeeDto>)responseDto.detail))
                {
                    _people = new UserDto
                    {
                        Id = employeeDto.Id,
                        Address = new AddressDto
                        {
                            Cep = employeeDto.Address.Cep,
                            Neighborhood = employeeDto.Address.Neighborhood,
                            Number = employeeDto.Address.Number,
                            Street = employeeDto.Address.Street
                        },
                        Mail = employeeDto.Mail,
                        Name = employeeDto.Name,
                        Phone = employeeDto.Phone
                    };
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
                await _accountController.Update(_people);
                alert.Text = "Usuário alterado com sucesso!";
            }
            else
            {
                alert = new Alert(AlertType.error);
                alert.Text = "Não foi possível alterar o usuário.";
            }
            alert.ShowAlert(PageContext);

            return Page();
        }
    }
}

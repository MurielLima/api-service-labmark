using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Phone = new PhoneDto();
            Address = new AddressDto();
        }
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        public PhoneDto Phone { get; set; }
        [EmailAddress(ErrorMessage = "O campo Email deve ser preenchido com um email válido.")]
        [DisplayName("Email")]
        public string Mail { get; set; }
        public AddressDto Address { get; set; }

    }
}

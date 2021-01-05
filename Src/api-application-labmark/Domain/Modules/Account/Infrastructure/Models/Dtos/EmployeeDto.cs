using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        public PhoneDto Phone { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        public AddressDto Address { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        [MaxLength(11)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [MaxLength(14)]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        [DisplayName("Estado de registro")]
        public string StateRegistration { get; set; }
        [DisplayName("Técnico responsável")]
        public string TechnicalManager { get; set; }
        public ICollection<PhoneDto> Phones { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        public AddressDto Address { get; set; }
    }
}

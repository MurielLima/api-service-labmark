using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos
{
    public class ClientDto
    {
        public ClientDto()
        {
            Phone = new PhoneDto();
            Address = new AddressDto();
        }
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        [MaxLength(11, ErrorMessage = "Deve conter no máximo 11 caracteres.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [MaxLength(14, ErrorMessage = "Deve conter no máximo 14 caracteres.")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }
        [MaxLength(1, ErrorMessage = "Deve conter no máximo 1 caracter.")]
        [DisplayName("Tipo pessoa")]
        [RegularExpression("F|J", ErrorMessage = "Campo Tipo pessoa deve ser preenchido com 'F' ou 'J'")]
        public string TypePerson { get; set; } = "F";
        [DisplayName("Estado de registro")]
        public string StateRegistration { get; set; }
        [DisplayName("Técnico responsável")]
        public string TechnicalManager { get; set; }
        public PhoneDto Phone { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Email")]
        public string Mail { get; set; }
        public AddressDto Address { get; set; }
    }
}

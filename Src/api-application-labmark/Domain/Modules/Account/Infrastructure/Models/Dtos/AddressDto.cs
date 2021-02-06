using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class AddressDto
    {
        [DisplayName("Logradouro")]
        public string Street { get; set; }
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }
        [DisplayName("Número")]
        [MaxLength(5, ErrorMessage = "Deve conter no máximo 5 caracteres.")]
        [RegularExpression("(([S]\\/[N])|\\d+)", ErrorMessage = "Campo Numero deve ser preenchido com o número do endereço ou 'S/N' para endereços sem número")]
        public string Number { get; set; }
        [MaxLength(8, ErrorMessage = "Deve conter no máximo 8 caracteres.")]
        [DisplayName("CEP")]
        public string Cep { get; set; }
    }
}

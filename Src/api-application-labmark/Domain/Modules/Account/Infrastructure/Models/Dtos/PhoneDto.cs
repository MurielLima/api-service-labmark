using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class PhoneDto
    {

        public int Id { get; set; }
        [MaxLength(3, ErrorMessage = "Deve conter no máximo 3 caracteres.")]
        public string Ddd { get; set; }
        [MaxLength(11, ErrorMessage = "Deve conter no máximo 11 caracteres.")]
        public string Number { get; set; }
    }
}

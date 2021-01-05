using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        public PhoneDto Phone { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        [DisplayName("Senha anterior")]
        public string OldPassword { get; set; }
        [DisplayName("Senha")]
        public string Password { get; set; }
        [DisplayName("Confirmar senha")]

        [Compare(nameof(Password), ErrorMessage = "Campos senha e confirmar senha devem ser iguais.")]
        public string ConfirmPassword { get; set; }
        public AddressDto Address { get; set; }
    }
}

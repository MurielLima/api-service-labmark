using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser preenchido com um email válido.")]
        [DisplayName("Email")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}

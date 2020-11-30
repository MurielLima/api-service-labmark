using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class UserDto
    {
        [MaxLength(255)]
        public string Nome { get; set; }
        [MaxLength(60)]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Cep { get; set; }
        [MaxLength(255)]
        public string Logradouro { get; set; }
        [MaxLength(30)]
        public string Numero { get; set; }
        [MaxLength(30)]
        public string Bairro { get; set; }
        public int IdPessoa { get; set; }
    }
}

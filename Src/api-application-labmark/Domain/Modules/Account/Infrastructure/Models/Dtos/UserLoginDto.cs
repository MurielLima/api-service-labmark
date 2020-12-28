using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        [Required]
        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}

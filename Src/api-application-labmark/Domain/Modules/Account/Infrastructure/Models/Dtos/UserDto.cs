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
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Phone { get; set; }
        [MaxLength(60)]
        [Required]
        public string Mail { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MaxLength(255)]
        public string ConfirmPassword { get; set; }
        [MaxLength(255)]
        public string Street { get; set; }
        [MaxLength(30)]
        public string Neighborhood { get; set; }
        [MaxLength(30)]
        public string Number { get; set; }
        [MaxLength(10)]
        public string Cep { get; set; }
    }
}

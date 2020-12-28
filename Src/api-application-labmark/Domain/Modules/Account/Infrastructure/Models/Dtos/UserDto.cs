﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Telefone")]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        [Required]
        [DisplayName("Senha")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Confirmar senha")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Logradouro")]
        public string Street { get; set; }
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }
        [DisplayName("Número")]
        public string Number { get; set; }
        [MaxLength(8)]
        [DisplayName("CEP")]
        public string Cep { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Account.Infrastructure.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        [DisplayName("Nome completo")]
        public string Name { get; set; }
        [DisplayName("Telefone")]
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        [DisplayName("Email")]
        public string Mail { get; set; }
        [DisplayName("Logradouro")]
        public string Street { get; set; }
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }
        [DisplayName("Número")]
        public string Number { get; set; }
        [DisplayName("CEP")]
        public string Cep { get; set; }
    }
}

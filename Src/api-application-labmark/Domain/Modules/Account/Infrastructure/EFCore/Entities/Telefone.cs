using System;
using System.Collections.Generic;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

#nullable disable

namespace Labmark.Models
{
    public partial class Telefone : Entity
    {
        public Telefone(string ddd, string numero)
        {
            Ddd = ddd;
            Numero = numero;
        }
        public int? FkPessoaId { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }

        public virtual Pessoa FkPessoa { get; set; }
    }
}

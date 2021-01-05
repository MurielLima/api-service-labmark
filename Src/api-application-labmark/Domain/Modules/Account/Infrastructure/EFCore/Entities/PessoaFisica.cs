using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    public partial class PessoaFisica
    {
        public int FkPessoaId { get; set; }
        [Column("CPF")]
        [MaxLength(11)]
        public string Cpf { get; set; }
        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaFisica))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

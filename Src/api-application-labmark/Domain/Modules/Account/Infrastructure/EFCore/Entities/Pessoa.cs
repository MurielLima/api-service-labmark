using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    public partial class Pessoa : Entity
    {
        public Pessoa()
        {
            Telefones = new HashSet<Telefone>();
        }
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(1)]
        [RegularExpression("F|J", ErrorMessage = "Campo TipoPessoa deve ser preenchido com 'F' ou 'J'")]
        public char TipoPessoa { get; set; } = 'F';
        [MaxLength(255)]
        public string Logradouro { get; set; }
        [MaxLength(5)]
        public string Numero { get; set; }
        [MaxLength(30)]
        public string Bairro { get; set; }
        [Column("CEP")]
        [MaxLength(8)]
        public string Cep { get; set; }
        public char TipoAcesso { get; set; } = 'C';
        [InverseProperty("FkPessoa")]
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("Pessoa", Schema = "LAB")]
    public partial class Pessoa : Entity
    {
        public Pessoa()
        {
            fkAmostras = new HashSet<Amostra>();
            fkSolicitacoes = new HashSet<Solicitacao>();
            fkTelefones = new HashSet<Telefone>();
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
        [InverseProperty("fkPessoa")]
        public virtual PessoaFisica fkPessoaFisica { get; set; }
        [InverseProperty("fkPessoa")]
        public virtual PessoaJuridica fkPessoaJuridica { get; set; }
        [InverseProperty(nameof(Amostra.fkPessoa))]
        public virtual ICollection<Amostra> fkAmostras { get; set; }

        [InverseProperty(nameof(Solicitacao.fkCliente))]
        public virtual ICollection<Solicitacao> fkSolicitacoes { get; set; }
        [InverseProperty(nameof(Telefone.fkPessoa))]
        public virtual ICollection<Telefone> fkTelefones { get; set; }
    }
}

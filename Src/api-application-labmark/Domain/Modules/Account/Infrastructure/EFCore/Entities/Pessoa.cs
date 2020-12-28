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
            Usuario = new HashSet<Usuario>();
        }

        [MaxLength(255)]
        public string Logradouro { get; set; }
        [Column("CEP")]
        [MaxLength(10)]
        public string Cep { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        public string Numero { get; set; }
        public string Telefone { get; set; }
        [MaxLength(30)]
        public string Bairro { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual PessoaFisica PessoaFisica { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

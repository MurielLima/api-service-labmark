using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Properties;

namespace Domain.Models
{
    public partial class Pessoa : EntityBase
    {
        public Pessoa()
        {
            Amostra = new HashSet<Amostra>();
            Telefone = new HashSet<Telefone>();
            Usuario = new HashSet<Usuario>();
        }

        [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Logradouro { get; set; }
        [Column("CEP")]
        [MaxLength(10, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Cep { get; set; }
        [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Nome { get; set; }
        [MaxLength(60, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Email { get; set; }
        public double? Numero { get; set; }
        [MaxLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Bairro { get; set; }
        [MaxLength(100, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string Rua { get; set; }
        [Column("fk_CEP_Id")]
        public int? FkCepId { get; set; }

        [ForeignKey(nameof(FkCepId))]
        [InverseProperty("Pessoa")]
        public virtual Cep FkCep { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual PessoaFisica PessoaFisica { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual ICollection<Amostra> Amostra { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual ICollection<Telefone> Telefone { get; set; }
        [InverseProperty("FkPessoa")]
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

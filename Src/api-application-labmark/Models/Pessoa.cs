using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Pessoa", Schema = "LAB")]
    public partial class Pessoa
    {
        public Pessoa()
        {
            Solicitacaos = new HashSet<Solicitacao>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(5)]
        public string Numero { get; set; }
        [StringLength(1)]
        public string TipoAcesso { get; set; }
        [StringLength(255)]
        public string Logradouro { get; set; }
        [StringLength(30)]
        public string Bairro { get; set; }
        [StringLength(8)]
        public string CEP { get; set; }
        [StringLength(20)]
        public string Complemento { get; set; }
        [StringLength(3)]
        public string DDD { get; set; }
        [StringLength(15)]
        public string Telefone { get; set; }
        [StringLength(1)]
        public string TipoPessoa { get; set; }

        [InverseProperty("fkPessoa")]
        public virtual PessoaFisica PessoaFisica { get; set; }
        [InverseProperty("fkPessoa")]
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        [InverseProperty(nameof(Solicitacao.fkPessoa))]
        public virtual ICollection<Solicitacao> Solicitacaos { get; set; }
    }
}

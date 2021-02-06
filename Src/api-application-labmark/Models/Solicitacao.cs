using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Solicitacao", Schema = "LAB")]
    public partial class Solicitacao
    {
        public Solicitacao()
        {
            Amostras = new HashSet<Amostra>();
            ArquivoLaudos = new HashSet<ArquivoLaudo>();
            Pergunta = new HashSet<Perguntum>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkPessoaId { get; set; }
        public bool? Julgamento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataRecebimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataConclusao { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.Solicitacaos))]
        public virtual Pessoa fkPessoa { get; set; }
        [InverseProperty(nameof(Amostra.fkSolicitacao))]
        public virtual ICollection<Amostra> Amostras { get; set; }
        [InverseProperty(nameof(ArquivoLaudo.fkSolicitacao))]
        public virtual ICollection<ArquivoLaudo> ArquivoLaudos { get; set; }
        [InverseProperty(nameof(Perguntum.fkSolicitacao))]
        public virtual ICollection<Perguntum> Pergunta { get; set; }
    }
}

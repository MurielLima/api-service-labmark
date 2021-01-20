using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Report.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities
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
        public int? fk_Pessoa_Id { get; set; }
        public bool? Julgamento { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRecebimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataConclusao { get; set; }

        [ForeignKey(nameof(fk_Pessoa_Id))]
        [InverseProperty(nameof(Pessoa.Solicitacoes))]
        public virtual Pessoa fk_Pessoa { get; set; }
        [InverseProperty(nameof(Amostra.fk_Solicitacao))]
        public virtual ICollection<Amostra> Amostras { get; set; }
        [InverseProperty(nameof(ArquivoLaudo.fk_Solicitacao))]
        public virtual ICollection<ArquivoLaudo> ArquivoLaudos { get; set; }
        [InverseProperty(nameof(Perguntum.fk_Solicitacao))]
        public virtual ICollection<Perguntum> Pergunta { get; set; }
    }
}

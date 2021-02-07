using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.ReportSample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities
{
    [Table("Solicitacao", Schema = "LAB")]
    public partial class Solicitacao
    {
        public Solicitacao()
        {
            Amostras = new HashSet<Amostra>();
            ArquivoLaudos = new HashSet<ArquivoLaudo>();
            Perguntum = new HashSet<Pergunta>();
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
        [InverseProperty(nameof(Pergunta.fkSolicitacao))]
        public virtual ICollection<Pergunta> Perguntum { get; set; }
    }
}

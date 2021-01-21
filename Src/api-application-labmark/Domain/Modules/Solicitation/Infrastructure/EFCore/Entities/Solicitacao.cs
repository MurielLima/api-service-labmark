using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Report.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities
{
    [Table("Solicitacao", Schema = "LAB")]
    public partial class Solicitacao
    {
        public Solicitacao()
        {
            fkAmostras = new HashSet<Amostra>();
            fkArquivoLaudos = new HashSet<ArquivoLaudo>();
            fkPerguntas = new HashSet<Pergunta>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkPessoaId { get; set; }
        public bool? Julgamento { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataRecebimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataConclusao { get; set; }

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.fkSolicitacoes))]
        public virtual Pessoa fkCliente { get; set; }
        [InverseProperty(nameof(Amostra.fkSolicitacao))]
        public virtual ICollection<Amostra> fkAmostras { get; set; }
        [InverseProperty(nameof(ArquivoLaudo.fkSolicitacao))]
        public virtual ICollection<ArquivoLaudo> fkArquivoLaudos { get; set; }
        [InverseProperty(nameof(Pergunta.fkSolicitacao))]
        public virtual ICollection<Pergunta> fkPerguntas { get; set; }
    }
}

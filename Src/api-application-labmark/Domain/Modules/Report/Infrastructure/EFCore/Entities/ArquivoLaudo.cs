using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Report.Infrastructure.EFCore.Entities
{
    [Table("ArquivoLaudo", Schema = "LAB")]
    public partial class ArquivoLaudo
    {
        [Key]
        public int Id { get; set; }
        public int? fkSolicitacaoId { get; set; }
        [StringLength(255)]
        public string Caminho { get; set; }
        [StringLength(255)]
        public string Hash { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataGerado { get; set; }

        [ForeignKey(nameof(fkSolicitacaoId))]
        [InverseProperty(nameof(Solicitacao.ArquivoLaudos))]
        public virtual Solicitacao fkSolicitacao { get; set; }
    }
}

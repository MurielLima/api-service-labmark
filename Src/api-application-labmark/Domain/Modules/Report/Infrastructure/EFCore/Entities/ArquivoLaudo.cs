using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Report.Infrastructure.EFCore.Entities
{
    [Table("ArquivoLaudo", Schema = "LAB")]
    public partial class ArquivoLaudo
    {
        [Key]
        public int Id { get; set; }
        public int? fk_Solicitacao_Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Hash { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataGerado { get; set; }
        [Required]
        [StringLength(255)]
        public string Caminho { get; set; }

        [ForeignKey(nameof(fk_Solicitacao_Id))]
        [InverseProperty(nameof(Solicitacao.ArquivoLaudos))]
        public virtual Solicitacao fk_Solicitacao { get; set; }
    }
}

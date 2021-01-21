using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Table("ContagemMBLB", Schema = "LAB")]
    public partial class ContagemMBLB
    {
        [Key]
        public int Id { get; set; }
        public int? fkEnsaiosPorAmostraId { get; set; }
        public double? Resultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }

        [ForeignKey(nameof(fkEnsaiosPorAmostraId))]
        [InverseProperty(nameof(EnsaiosPorAmostra.fkContagemMBLBs))]
        public virtual EnsaiosPorAmostra fkEnsaiosPorAmostra { get; set; }
    }
}

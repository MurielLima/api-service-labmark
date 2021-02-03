using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("EnsaiosPorAmostra", Schema = "LAB")]
    public partial class EnsaiosPorAmostra
    {
        public EnsaiosPorAmostra()
        {
            fkColiformesEscherichia = new HashSet<ColiformesEscherichia>();
            fkContagemMBLBs = new HashSet<ContagemMBLB>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkEnsaioId { get; set; }
        public int? fkAmostraId { get; set; }

        [ForeignKey(nameof(fkAmostraId))]
        [InverseProperty(nameof(Amostra.fkEnsaiosPorAmostras))]
        public virtual Amostra fkAmostra { get; set; }
        [ForeignKey(nameof(fkEnsaioId))]
        [InverseProperty(nameof(Ensaio.fkEnsaiosPorAmostras))]
        public virtual Ensaio fkEnsaio { get; set; }
        [InverseProperty(nameof(ColiformesEscherichia.fkEnsaiosPorAmostra))]
        public virtual ICollection<ColiformesEscherichia> fkColiformesEscherichia { get; set; }
        [InverseProperty(nameof(ContagemMBLB.fkEnsaiosPorAmostra))]
        public virtual ICollection<ContagemMBLB> fkContagemMBLBs { get; set; }
    }
}

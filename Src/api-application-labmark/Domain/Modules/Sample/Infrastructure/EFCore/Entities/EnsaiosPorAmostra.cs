using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("EnsaiosPorAmostra", Schema = "LAB")]
    public partial class EnsaiosPorAmostra
    {
        public EnsaiosPorAmostra()
        {
            ColiformesEscherichia = new HashSet<ColiformesEscherichium>();
            ContagemMBLBs = new HashSet<ContagemMBLB>();
        }

        [Key]
        public int Id { get; set; }
        public int? fk_Ensaio_Id { get; set; }
        public int? fk_Amostra_Id { get; set; }

        [ForeignKey(nameof(fk_Amostra_Id))]
        [InverseProperty(nameof(Amostra.EnsaiosPorAmostras))]
        public virtual Amostra fk_Amostra { get; set; }
        [ForeignKey(nameof(fk_Ensaio_Id))]
        [InverseProperty(nameof(Ensaio.EnsaiosPorAmostras))]
        public virtual Ensaio fk_Ensaio { get; set; }
        [InverseProperty(nameof(ColiformesEscherichium.fk_EnsaiosPorAmostra))]
        public virtual ICollection<ColiformesEscherichium> ColiformesEscherichia { get; set; }
        [InverseProperty(nameof(ContagemMBLB.fk_EnsaiosPorAmostra))]
        public virtual ICollection<ContagemMBLB> ContagemMBLBs { get; set; }
    }
}

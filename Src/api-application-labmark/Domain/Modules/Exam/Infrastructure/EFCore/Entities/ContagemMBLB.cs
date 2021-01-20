using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Models
{
    [Table("ContagemMBLB", Schema = "LAB")]
    public partial class ContagemMBLB
    {
        [Key]
        public int Id { get; set; }
        public int? fk_EnsaiosPorAmostra_Id { get; set; }
        public double? Resultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }

        [ForeignKey(nameof(fk_EnsaiosPorAmostra_Id))]
        [InverseProperty(nameof(EnsaiosPorAmostra.ContagemMBLBs))]
        public virtual EnsaiosPorAmostra fk_EnsaiosPorAmostra { get; set; }
    }
}

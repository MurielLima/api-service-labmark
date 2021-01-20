using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Table("ColiformesEscherichia", Schema = "LAB")]
    public partial class ColiformesEscherichium
    {
        [Key]
        public int Id { get; set; }
        public int? fk_EnsaiosPorAmostra_Id { get; set; }
        public int? Ponteira_Alcada { get; set; }
        public int? BanhoMaria { get; set; }
        public double? Escherichia { get; set; }
        public double? Brilla { get; set; }
        public int? BOD { get; set; }
        public int? Fluxo_Micropipetador { get; set; }
        public int? ColiformesTotais { get; set; }
        public int? ColiformesTermotolerantes { get; set; }
        public double? Resultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPreenchimento { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }

        [ForeignKey(nameof(fk_EnsaiosPorAmostra_Id))]
        [InverseProperty(nameof(EnsaiosPorAmostra.ColiformesEscherichia))]
        public virtual EnsaiosPorAmostra fk_EnsaiosPorAmostra { get; set; }
    }
}

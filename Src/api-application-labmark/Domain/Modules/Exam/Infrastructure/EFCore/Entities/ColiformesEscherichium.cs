using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Table("ColiformesEscherichia", Schema = "LAB")]
    public partial class ColiformesEscherichium
    {
        [Key]
        public int Id { get; set; }
        public int? fkEnsaiosPorAmostraId { get; set; }
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

        [ForeignKey(nameof(fkEnsaiosPorAmostraId))]
        [InverseProperty(nameof(EnsaiosPorAmostra.fkColiformesEscherichia))]
        public virtual EnsaiosPorAmostra fkEnsaiosPorAmostra { get; set; }
    }
}

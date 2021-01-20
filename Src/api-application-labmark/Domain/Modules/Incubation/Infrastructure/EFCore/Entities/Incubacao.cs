using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities
{
    [Table("Incubacao", Schema = "LAB")]
    public partial class Incubacao
    {
        [Key]
        public int Id { get; set; }
        public int? fk_Experimento_Id { get; set; }
        public int? TemperaturaIncubacao { get; set; }
        public int? MinutosIncubacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAbertura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFinalizacao { get; set; }

        [ForeignKey(nameof(fk_Experimento_Id))]
        [InverseProperty(nameof(Experimento.Incubacaos))]
        public virtual Experimento fk_Experimento { get; set; }
    }
}

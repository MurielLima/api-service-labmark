using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("ColiformesEscherichia", Schema = "LAB")]
    public partial class ColiformesEscherichium
    {
        public ColiformesEscherichium()
        {
            DiluicaoColiformesEscherichia = new HashSet<DiluicaoColiformesEscherichium>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkEnsaiosPorAmostraId { get; set; }
        public int? Ponteira_Alcada { get; set; }
        public double? BanhoMaria { get; set; }
        public double? ResultadoColiformesTermotolerantes { get; set; }
        public double? Escherichia { get; set; }
        public double? Brilla { get; set; }
        public int? BOD { get; set; }
        public int? Fluxo_Micropipetador { get; set; }
        public double? ResultadoColiformesTotais { get; set; }
        public double? LeituraTotais { get; set; }
        public double? LeituraTermotolerantes { get; set; }
        public int? Pipeta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPreenchimento { get; set; }

        [ForeignKey(nameof(fkEnsaiosPorAmostraId))]
        [InverseProperty(nameof(EnsaiosPorAmostra.ColiformesEscherichia))]
        public virtual EnsaiosPorAmostra fkEnsaiosPorAmostra { get; set; }
        [InverseProperty(nameof(DiluicaoColiformesEscherichium.fkColiformesEscherichia))]
        public virtual ICollection<DiluicaoColiformesEscherichium> DiluicaoColiformesEscherichia { get; set; }
    }
}

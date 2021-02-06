using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("ContagemMBLB", Schema = "LAB")]
    public partial class ContagemMBLB
    {
        [Key]
        public int Id { get; set; }
        public int? fkEnsaiosPorAmostraId { get; set; }
        public double? Leitura { get; set; }
        public int? Diluicao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPreenchimento { get; set; }
        public double? Resultado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }

        [ForeignKey(nameof(fkEnsaiosPorAmostraId))]
        [InverseProperty(nameof(EnsaiosPorAmostra.ContagemMBLBs))]
        public virtual EnsaiosPorAmostra fkEnsaiosPorAmostra { get; set; }
    }
}

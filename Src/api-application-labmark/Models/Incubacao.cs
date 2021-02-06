using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Incubacao", Schema = "LAB")]
    public partial class Incubacao
    {
        [Key]
        public int Id { get; set; }
        public int? fkExperimentoId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataAbertura { get; set; }
        public int? MinutosIncubacao { get; set; }
        public int? TemperaturaIncubacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFinalizacao { get; set; }

        [ForeignKey(nameof(fkExperimentoId))]
        [InverseProperty(nameof(Experimento.Incubacaos))]
        public virtual Experimento fkExperimento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("DiluicaoColiformesEscherichia", Schema = "LAB")]
    public partial class DiluicaoColiformesEscherichium
    {
        [Key]
        public int Id { get; set; }
        public int? fkColiformesEscherichiaId { get; set; }
        public int? Ordem { get; set; }
        public int? Diluicao { get; set; }
        [StringLength(10)]
        public string Leitura { get; set; }
        public bool? Escolhida { get; set; }

        [ForeignKey(nameof(fkColiformesEscherichiaId))]
        [InverseProperty(nameof(ColiformesEscherichium.DiluicaoColiformesEscherichia))]
        public virtual ColiformesEscherichium fkColiformesEscherichia { get; set; }
    }
}

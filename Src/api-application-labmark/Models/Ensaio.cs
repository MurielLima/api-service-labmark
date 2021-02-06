using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Ensaio", Schema = "LAB")]
    public partial class Ensaio
    {
        public Ensaio()
        {
            EnsaiosPorAmostras = new HashSet<EnsaiosPorAmostra>();
        }

        [Key]
        public int Id { get; set; }
        public int? Codigo { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }
        [StringLength(255)]
        public string Metodologia { get; set; }
        [StringLength(255)]
        public string Referencia { get; set; }

        [InverseProperty(nameof(EnsaiosPorAmostra.fkEnsaio))]
        public virtual ICollection<EnsaiosPorAmostra> EnsaiosPorAmostras { get; set; }
    }
}

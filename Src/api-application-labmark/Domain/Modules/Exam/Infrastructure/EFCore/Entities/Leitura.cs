using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Leitura", Schema = "LAB")]
    public partial class Leitura
    {
        public Leitura()
        {
            Diluicaos = new HashSet<Diluicao>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Leitura")]
        public double Leitura1 { get; set; }

        [InverseProperty(nameof(Diluicao.fk_Leitura))]
        public virtual ICollection<Diluicao> Diluicaos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Ponteira", Schema = "LAB")]
    public partial class Ponteira
    {
        [Key]
        public int Id { get; set; }
        public int? fk_DiluicaoAmostra_Id { get; set; }
        public int Codigo { get; set; }
        public int Valor { get; set; }

        [ForeignKey(nameof(fk_DiluicaoAmostra_Id))]
        [InverseProperty(nameof(DiluicaoAmostra.Ponteiras))]
        public virtual DiluicaoAmostra fk_DiluicaoAmostra { get; set; }
    }
}

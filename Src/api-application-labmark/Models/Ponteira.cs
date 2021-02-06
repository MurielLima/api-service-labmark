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
        public int? Codigo { get; set; }
        [Key]
        public int Id { get; set; }
        public int? Valor { get; set; }
        public int? fkDiluicaoAmostraId { get; set; }

        [ForeignKey(nameof(fkDiluicaoAmostraId))]
        [InverseProperty(nameof(DiluicaoAmostra.Ponteiras))]
        public virtual DiluicaoAmostra fkDiluicaoAmostra { get; set; }
    }
}

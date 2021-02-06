using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("AguaDiluicao", Schema = "LAB")]
    public partial class AguaDiluicao
    {
        [Key]
        public int Id { get; set; }
        public int? fkDiluicaoAmostraId { get; set; }
        public int? Codigo { get; set; }
        public int? Valor { get; set; }

        [ForeignKey(nameof(fkDiluicaoAmostraId))]
        [InverseProperty(nameof(DiluicaoAmostra.AguaDiluicaos))]
        public virtual DiluicaoAmostra fkDiluicaoAmostra { get; set; }
    }
}

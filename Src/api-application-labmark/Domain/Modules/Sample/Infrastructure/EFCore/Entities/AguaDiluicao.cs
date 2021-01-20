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
        public int? fk_DiluicaoAmostra_Id { get; set; }
        public int Codigo { get; set; }
        public int Valor { get; set; }

        [ForeignKey(nameof(fk_DiluicaoAmostra_Id))]
        [InverseProperty(nameof(DiluicaoAmostra.AguaDiluicaos))]
        public virtual DiluicaoAmostra fk_DiluicaoAmostra { get; set; }
    }
}

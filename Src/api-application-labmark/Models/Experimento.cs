using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Experimento", Schema = "LAB")]
    public partial class Experimento
    {
        public Experimento()
        {
            Incubacaos = new HashSet<Incubacao>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkDiluicaoAmostraId { get; set; }
        public int? BOD { get; set; }
        [StringLength(10)]
        public string Meio { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }

        [ForeignKey(nameof(fkDiluicaoAmostraId))]
        [InverseProperty(nameof(DiluicaoAmostra.Experimentos))]
        public virtual DiluicaoAmostra fkDiluicaoAmostra { get; set; }
        [InverseProperty(nameof(Incubacao.fkExperimento))]
        public virtual ICollection<Incubacao> Incubacaos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("DiluicaoAmostra", Schema = "LAB")]
    public partial class DiluicaoAmostra
    {
        public DiluicaoAmostra()
        {
            AguaDiluicaos = new HashSet<AguaDiluicao>();
            Experimentos = new HashSet<Experimento>();
            Ponteiras = new HashSet<Ponteira>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkAmostraId { get; set; }
        public int? Homogeneizador { get; set; }
        public int? Agitador { get; set; }
        public int? Pipeta { get; set; }
        public int? Micropipeta { get; set; }
        public double? Placa { get; set; }
        public int? Local { get; set; }
        [StringLength(30)]
        public string Outros { get; set; }

        [ForeignKey(nameof(fkAmostraId))]
        [InverseProperty(nameof(Amostra.DiluicaoAmostras))]
        public virtual Amostra fkAmostra { get; set; }
        [InverseProperty(nameof(AguaDiluicao.fkDiluicaoAmostra))]
        public virtual ICollection<AguaDiluicao> AguaDiluicaos { get; set; }
        [InverseProperty(nameof(Experimento.fkDiluicaoAmostra))]
        public virtual ICollection<Experimento> Experimentos { get; set; }
        [InverseProperty(nameof(Ponteira.fkDiluicaoAmostra))]
        public virtual ICollection<Ponteira> Ponteiras { get; set; }
    }
}

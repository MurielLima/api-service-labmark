using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("Experimento", Schema = "LAB")]
    public partial class Experimento
    {
        public Experimento()
        {
            fkIncubacoes = new HashSet<Incubacao>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkDiluicaoAmostraId { get; set; }
        [Required]
        [StringLength(10)]
        public string Meio { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public int? BOD { get; set; }

        [ForeignKey(nameof(fkDiluicaoAmostraId))]
        [InverseProperty(nameof(DiluicaoAmostra.fkExperimentos))]
        public virtual DiluicaoAmostra fkDiluicaoAmostra { get; set; }
        [InverseProperty(nameof(Incubacao.fkExperimento))]
        public virtual ICollection<Incubacao> fkIncubacoes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Keyless]
    [Table("DiluicaoPorExperimento", Schema = "LAB")]
    public partial class DiluicaoPorExperimento
    {
        public int? fkExperimentoId { get; set; }
        public int? fkDiluicaoId { get; set; }

        [ForeignKey(nameof(fkDiluicaoId))]
        public virtual Diluicao fkDiluicao { get; set; }
        [ForeignKey(nameof(fkExperimentoId))]
        public virtual Experimento fkExperimento { get; set; }
    }
}

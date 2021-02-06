using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
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
        [InverseProperty(nameof(DiluicaoAmostra.fkPonteiras))]
        public virtual DiluicaoAmostra fkDiluicaoAmostra { get; set; }
    }
}

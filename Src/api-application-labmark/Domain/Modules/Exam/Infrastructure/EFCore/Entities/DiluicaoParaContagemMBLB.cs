using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Keyless]
    [Table("DiluicaoParaContagemMBLB", Schema = "LAB")]
    public partial class DiluicaoParaContagemMBLB
    {
        public int? fkContagemMBLBId { get; set; }
        public int? fkLeituraId { get; set; }

        [ForeignKey(nameof(fkContagemMBLBId))]
        public virtual ContagemMBLB fkContagemMBLB { get; set; }
        [ForeignKey(nameof(fkLeituraId))]
        public virtual Leitura fkLeitura { get; set; }
    }
}

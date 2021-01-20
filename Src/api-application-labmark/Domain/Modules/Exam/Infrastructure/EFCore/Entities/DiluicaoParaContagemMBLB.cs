using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Keyless]
    [Table("DiluicaoParaContagemMBLB", Schema = "LAB")]
    public partial class DiluicaoParaContagemMBLB
    {
        public int? fk_ContagemMBLB_Id { get; set; }
        public int? fk_Leitura_Id { get; set; }

        [ForeignKey(nameof(fk_ContagemMBLB_Id))]
        public virtual ContagemMBLB fk_ContagemMBLB { get; set; }
        [ForeignKey(nameof(fk_Leitura_Id))]
        public virtual Leitura fk_Leitura { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Keyless]
    [Table("DiluicaoParaColiformesEscherichia", Schema = "LAB")]
    public partial class DiluicaoParaColiformesEscherichia
    {
        public int? fkColiformesEscherichiaId { get; set; }
        public int? fkLeituraId { get; set; }

        [ForeignKey(nameof(fkColiformesEscherichiaId))]
        public virtual ColiformesEscherichia fkColiformesEscherichia { get; set; }
        [ForeignKey(nameof(fkLeituraId))]
        public virtual Leitura fkLeitura { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("Diluicao", Schema = "LAB")]
    public partial class Diluicao
    {
        [Key]
        public int Id { get; set; }
        public int? fkLeituraId { get; set; }
        [Column("Diluicao")]
        public double Diluicao1 { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }

        [ForeignKey(nameof(fkLeituraId))]
        [InverseProperty(nameof(Leitura.fkDiluicoes))]
        public virtual Leitura fkLeitura { get; set; }
    }
}

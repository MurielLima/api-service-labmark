using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Table("Leitura", Schema = "LAB")]
    public partial class Leitura
    {
        public Leitura()
        {
            fkDiluicoes = new HashSet<Diluicao>();
        }

        public int Code { get; set; }



        [Key]
        public int Id { get; set; }
        [Column("Leitura")]
        public double Leitura1 { get; set; }

        [InverseProperty(nameof(Diluicao.fkLeitura))]
        public virtual ICollection<Diluicao> fkDiluicoes { get; set; }
    }
}

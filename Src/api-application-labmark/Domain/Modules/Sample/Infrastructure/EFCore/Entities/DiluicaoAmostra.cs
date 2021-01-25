using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("DiluicaoAmostra", Schema = "LAB")]
    public partial class DiluicaoAmostra
    {
        public DiluicaoAmostra()
        {
            fkAguaDiluicaos = new HashSet<AguaDiluicao>();
            fkExperimentos = new HashSet<Experimento>();
            fkPonteiras = new HashSet<Ponteira>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkAmostraId { get; set; }
        public int? Micropipeta { get; set; }
        public int? Pipeta { get; set; }
        public int? Homogeneizador { get; set; }
        public int? Agitador { get; set; }
        public double? Placa { get; set; }
        public int? Local { get; set; }
        [StringLength(30)]
        public string Outros { get; set; }

        [ForeignKey(nameof(fkAmostraId))]
        [InverseProperty(nameof(Amostra.fkDiluicaoAmostras))]
        public virtual Amostra fkAmostra { get; set; }
        [InverseProperty(nameof(AguaDiluicao.fkDiluicaoAmostra))]
        public virtual ICollection<AguaDiluicao> fkAguaDiluicaos { get; set; }
        [InverseProperty(nameof(Experimento.fkDiluicaoAmostra))]
        public virtual ICollection<Experimento> fkExperimentos { get; set; }
        [InverseProperty(nameof(Ponteira.fkDiluicaoAmostra))]
        public virtual ICollection<Ponteira> fkPonteiras { get; set; }
    }
}

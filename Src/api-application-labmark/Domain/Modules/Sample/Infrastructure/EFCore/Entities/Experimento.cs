using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Models
{
    [Table("Experimento", Schema = "LAB")]
    public partial class Experimento
    {
        public Experimento()
        {
            Incubacaos = new HashSet<Incubacao>();
        }

        [Key]
        public int Id { get; set; }
        public int? fk_DiluicaoAmostra_Id { get; set; }
        [Required]
        [StringLength(10)]
        public string Meio { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public int? BOD { get; set; }

        [ForeignKey(nameof(fk_DiluicaoAmostra_Id))]
        [InverseProperty(nameof(DiluicaoAmostra.Experimentos))]
        public virtual DiluicaoAmostra fk_DiluicaoAmostra { get; set; }
        [InverseProperty(nameof(Incubacao.fk_Experimento))]
        public virtual ICollection<Incubacao> Incubacaos { get; set; }
    }
}

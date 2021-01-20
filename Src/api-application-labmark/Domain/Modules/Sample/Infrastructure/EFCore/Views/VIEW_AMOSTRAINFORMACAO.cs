using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Models
{
    [Keyless]
    public partial class VIEW_AMOSTRAINFORMACAO
    {
        [Required]
        [StringLength(100)]
        public string DESCRICAO { get; set; }
        [StringLength(30)]
        public string DATAFABRICACAO { get; set; }
        [StringLength(30)]
        public string DATAVALIDADE { get; set; }
        [StringLength(30)]
        public string LOTE { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DATARECEBIMENTO { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DATACONCLUSAO { get; set; }
        [StringLength(30)]
        public string LACRE { get; set; }
        [StringLength(60)]
        public string CERTIFICADOOFICIAL { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DATAEMISSAO { get; set; }
        [StringLength(30)]
        public string TAA { get; set; }
        [StringLength(30)]
        public string OFICIO { get; set; }
        public double? TEMPERATURA { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{

    [Table("DiluicaoColiformesEscherichia", Schema = "LAB")]
    public partial class DiluicaoColiformesEscherichia
    {
        [Key]
        public int Id { get; set; }
        public int? fkColiformesEscherichiaId { get; set; }
        public int? Ordem { get; set; }
        public int? Diluicao { get; set; }
        [StringLength(10)]
        public string Leitura { get; set; }
        public bool? Escolhida { get; set; }

        [ForeignKey(nameof(fkColiformesEscherichiaId))]
        [InverseProperty(nameof(ColiformesEscherichia.DiluicaoColiformesEscherichium))]
        public virtual ColiformesEscherichia fkColiformesEscherichia { get; set; }
    }



}

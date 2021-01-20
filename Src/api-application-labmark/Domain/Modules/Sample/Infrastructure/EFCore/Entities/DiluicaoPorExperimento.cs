using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Keyless]
    [Table("DiluicaoPorExperimento", Schema = "LAB")]
    public partial class DiluicaoPorExperimento
    {
        public int? fk_Experimento_Id { get; set; }
        public int? fk_Diluicao_Id { get; set; }

        [ForeignKey(nameof(fk_Diluicao_Id))]
        public virtual Diluicao fk_Diluicao { get; set; }
        [ForeignKey(nameof(fk_Experimento_Id))]
        public virtual Experimento fk_Experimento { get; set; }
    }
}

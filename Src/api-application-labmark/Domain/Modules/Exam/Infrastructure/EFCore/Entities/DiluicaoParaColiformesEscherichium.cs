using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Keyless]
    [Table("DiluicaoParaColiformesEscherichia", Schema = "LAB")]
    public partial class DiluicaoParaColiformesEscherichium
    {
        public int? fk_ColiformesEscherichia_Id { get; set; }
        public int? fk_Leitura_Id { get; set; }

        [ForeignKey(nameof(fk_ColiformesEscherichia_Id))]
        public virtual ColiformesEscherichium fk_ColiformesEscherichia { get; set; }
        [ForeignKey(nameof(fk_Leitura_Id))]
        public virtual Leitura fk_Leitura { get; set; }
    }
}

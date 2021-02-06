﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("EnsaiosPorAmostra", Schema = "LAB")]
    public partial class EnsaiosPorAmostra
    {
        public EnsaiosPorAmostra()
        {
            ColiformesEscherichia = new HashSet<ColiformesEscherichium>();
            ContagemMBLBs = new HashSet<ContagemMBLB>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkEnsaioId { get; set; }
        public int? fkAmostraId { get; set; }

        [ForeignKey(nameof(fkAmostraId))]
        [InverseProperty(nameof(Amostra.EnsaiosPorAmostras))]
        public virtual Amostra fkAmostra { get; set; }
        [ForeignKey(nameof(fkEnsaioId))]
        [InverseProperty(nameof(Ensaio.EnsaiosPorAmostras))]
        public virtual Ensaio fkEnsaio { get; set; }
        [InverseProperty(nameof(ColiformesEscherichium.fkEnsaiosPorAmostra))]
        public virtual ICollection<ColiformesEscherichium> ColiformesEscherichia { get; set; }
        [InverseProperty(nameof(ContagemMBLB.fkEnsaiosPorAmostra))]
        public virtual ICollection<ContagemMBLB> ContagemMBLBs { get; set; }
    }
}
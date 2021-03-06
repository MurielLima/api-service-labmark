﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities
{
    [Table("ColiformesEscherichia", Schema = "LAB")]
    public partial class ColiformesEscherichia
    {
        public ColiformesEscherichia()
        {
            DiluicaoColiformesEscherichium = new HashSet<DiluicaoColiformesEscherichia>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkEnsaiosPorAmostraId { get; set; }
        public int? Ponteira_Alcada { get; set; }
        public double? BanhoMaria { get; set; }
        public double? ResultadoColiformesTermotolerantes { get; set; }
        public double? Escherichia { get; set; }
        public double? Brilla { get; set; }
        public int? BOD { get; set; }
        public int? Fluxo_Micropipetador { get; set; }
        public double? ResultadoColiformesTotais { get; set; }
        public double? LeituraTotais { get; set; }
        public double? LeituraTermotolerantes { get; set; }
        public int? Pipeta { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataResultado { get; set; }
        [StringLength(255)]
        public string Observacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataPreenchimento { get; set; }

        [ForeignKey(nameof(fkEnsaiosPorAmostraId))]
        [InverseProperty(nameof(EnsaiosPorAmostra.ColiformesEscherichium))]
        public virtual EnsaiosPorAmostra fkEnsaiosPorAmostra { get; set; }
        [InverseProperty(nameof(DiluicaoColiformesEscherichia.fkColiformesEscherichia))]
        public virtual ICollection<DiluicaoColiformesEscherichia> DiluicaoColiformesEscherichium { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Amostra", Schema = "LAB")]
    public partial class Amostra
    {
        public Amostra()
        {
            DiluicaoAmostras = new HashSet<DiluicaoAmostra>();
            EnsaiosPorAmostras = new HashSet<EnsaiosPorAmostra>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkSolicitacaoId { get; set; }
        [StringLength(100)]
        public string Descricao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFabricacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataValidade { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public double? Temperatura { get; set; }
        [StringLength(30)]
        public string Lacre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataColeta { get; set; }
        [StringLength(30)]
        public string TAA { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataEmissao { get; set; }
        [StringLength(60)]
        public string CertificadoOficial { get; set; }
        [StringLength(30)]
        public string Oficio { get; set; }

        [ForeignKey(nameof(fkSolicitacaoId))]
        [InverseProperty(nameof(Solicitacao.Amostras))]
        public virtual Solicitacao fkSolicitacao { get; set; }
        [InverseProperty(nameof(DiluicaoAmostra.fkAmostra))]
        public virtual ICollection<DiluicaoAmostra> DiluicaoAmostras { get; set; }
        [InverseProperty(nameof(EnsaiosPorAmostra.fkAmostra))]
        public virtual ICollection<EnsaiosPorAmostra> EnsaiosPorAmostras { get; set; }
    }
}

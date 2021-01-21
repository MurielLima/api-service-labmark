using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("Amostra", Schema = "LAB")]
    public partial class Amostra
    {
        public Amostra()
        {
            fkDiluicaoAmostras = new HashSet<DiluicaoAmostra>();
            fkEnsaiosPorAmostras = new HashSet<EnsaiosPorAmostra>();
        }

        [Key]
        public int Id { get; set; }
        public int? fkSolicitacaoId { get; set; }
        public int? fkPessoaId { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        public double? Temperatura { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataValidade { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataFabricacao { get; set; }
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

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.fkAmostras))]
        public virtual Pessoa fkPessoa { get; set; }
        [ForeignKey(nameof(fkSolicitacaoId))]
        [InverseProperty(nameof(Solicitacao.fkAmostras))]
        public virtual Solicitacao fkSolicitacao { get; set; }
        [InverseProperty(nameof(DiluicaoAmostra.fkAmostra))]
        public virtual ICollection<DiluicaoAmostra> fkDiluicaoAmostras { get; set; }
        [InverseProperty(nameof(EnsaiosPorAmostra.fkAmostra))]
        public virtual ICollection<EnsaiosPorAmostra> fkEnsaiosPorAmostras { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities
{
    [Table("Pergunta", Schema = "LAB")]
    public partial class Pergunta
    {
        [Key]
        public int Id { get; set; }
        public int? fkSolicitacaoId { get; set; }
        public int Codigo { get; set; }
        public bool Resposta { get; set; }

        [ForeignKey(nameof(fkSolicitacaoId))]
        [InverseProperty(nameof(Solicitacao.fkPerguntas))]
        public virtual Solicitacao fkSolicitacao { get; set; }
    }
}

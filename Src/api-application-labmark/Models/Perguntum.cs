using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("Pergunta", Schema = "LAB")]
    public partial class Perguntum
    {
        [Key]
        public int Id { get; set; }
        public int? fkSolicitacaoId { get; set; }
        public int? Codigo { get; set; }
        public bool? Resposta { get; set; }

        [ForeignKey(nameof(fkSolicitacaoId))]
        [InverseProperty(nameof(Solicitacao.Pergunta))]
        public virtual Solicitacao fkSolicitacao { get; set; }
    }
}

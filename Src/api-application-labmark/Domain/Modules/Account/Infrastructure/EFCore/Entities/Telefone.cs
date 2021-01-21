using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;


namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("Telefone", Schema = "LAB")]
    public partial class Telefone : Entity
    {
        public int? FkPessoaId { get; set; }
        [MaxLength(3)]
        public string Ddd { get; set; }
        [MaxLength(15)]
        public string Numero { get; set; }

        [ForeignKey(nameof(FkPessoaId))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

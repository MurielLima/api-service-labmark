using System.ComponentModel.DataAnnotations;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

#nullable disable

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    public partial class Telefone : Entity
    {
        public int? FkPessoaId { get; set; }
        [MaxLength(3)]
        public string Ddd { get; set; }
        [MaxLength(15)]
        public string Numero { get; set; }

        public virtual Pessoa FkPessoa { get; set; }
    }
}

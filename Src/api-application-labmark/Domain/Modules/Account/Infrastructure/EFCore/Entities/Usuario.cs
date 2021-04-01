using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities

{
    public partial class Usuario : IdentityUser<int>
    {
        [ForeignKey(nameof(FkPessoaId))]
        [Required]
        [Column("fkPessoaId")]
        public int FkPessoaId { get; set; }
        [Column("isActive")]
        public bool isActive { get; set; }
        public virtual Pessoa FkPessoa { get; set; }
    }
}

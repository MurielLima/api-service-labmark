using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities

{
    public partial class Usuario : IdentityUser<int>
    {
        [ForeignKey(nameof(FkPessoaId))]
        [Required]
        [Column("fk_Pessoa_Id")]
        public int FkPessoaId { get; set; }
        [InverseProperty(nameof(Pessoa.Usuario))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Properties;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public partial class Usuario : IdentityUser<int>
    {
        [NotMapped]
        [MinLength(6, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(Resources))]
        [RegularExpression("^(?=.*[a-zà-ú])(?=.*[A-ZÀ-Ú])(?=.*\\d)(?=.*[@$!%*?&])[A-ZÀ-Úa-zà-ú\\d@$!%*?&]{6,}$", ErrorMessageResourceName = "RequiredPassword", ErrorMessageResourceType = typeof(Resources))]
        public string Password { get; set; }
        [Key]
        [Required]
        [Column("fk_Pessoa_Id")]
        public int? FkPessoaId { get; set; }
        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.Usuario))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

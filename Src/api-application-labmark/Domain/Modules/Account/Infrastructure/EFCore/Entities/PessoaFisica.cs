using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("PessoaFisica", Schema = "LAB")]
    [Index(nameof(CPF), Name = "UQ__PessoaFi__C1F8973120D239E3", IsUnique = true)]
    public partial class PessoaFisica
    {
        [Key]
        public int fkPessoaId { get; set; }
        [StringLength(11)]
        public string CPF { get; set; }

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaFisica))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

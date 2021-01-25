using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("PessoaFisica", Schema = "LAB")]
    [Index(nameof(Cpf), Name = "UQ__PessoaFi__C1F8973120D239E3", IsUnique = true)]
    public partial class PessoaFisica
    {
        [Key]
        public int FkPessoaId { get; set; }
        [Column("CPF")]
        [MaxLength(11)]
        [Required]
        public string Cpf { get; set; }
        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.fkPessoaFisica))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

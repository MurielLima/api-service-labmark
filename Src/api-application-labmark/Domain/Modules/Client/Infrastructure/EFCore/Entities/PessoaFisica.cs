using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labmark.Domain.Modules.Client.Infrastructure.EFCore.Entities
{
    public partial class PessoaFisica
    {
        public int FkPessoaId { get; set; }
        [Column("CPF")]
        [MaxLength(11)]
        public string Cpf { get; set; }
        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaFisica))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

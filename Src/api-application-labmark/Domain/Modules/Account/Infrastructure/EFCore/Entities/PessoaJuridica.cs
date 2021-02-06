using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("PessoaJuridica", Schema = "LAB")]
    [Index(nameof(CNPJ), Name = "UQ__PessoaJu__AA57D6B424D28EF9", IsUnique = true)]
    public partial class PessoaJuridica
    {
        [Key]
        public int fkPessoaId { get; set; }
        [StringLength(14)]
        public string CNPJ { get; set; }
        [StringLength(30)]
        public string InscricaoEstadual { get; set; }
        [StringLength(255)]
        public string ResponsavelTecnico { get; set; }

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaJuridica))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

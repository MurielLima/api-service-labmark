using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    [Table("PessoaJuridica", Schema = "LAB")]
    [Index(nameof(Cnpj), Name = "UQ__PessoaJu__AA57D6B424D28EF9", IsUnique = true)]
    public partial class PessoaJuridica
    {
        [Key]
        public int FkPessoaId { get; set; }
        [Column("CNPJ")]
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(30)]
        public string InscricaoEstadual { get; set; }
        [MaxLength(255)]
        public string ResponsavelTecnico { get; set; }

        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.fkPessoaJuridica))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

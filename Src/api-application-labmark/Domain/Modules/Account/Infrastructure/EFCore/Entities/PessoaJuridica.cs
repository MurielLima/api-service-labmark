using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Labmark.Domain.Shared.Infrastructure.EFCore.Entities;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    public partial class PessoaJuridica : Entity
    {
        [Column("CNPJ")]
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(30)]
        public string InscricaoEstadual { get; set; }
        [MaxLength(255)]
        public string ResponsavelTecnico { get; set; }
        [Column("fk_Pessoa_Id")]
        public int? FkPessoaId { get; set; }

        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaJuridica))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

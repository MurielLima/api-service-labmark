using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities
{
    public partial class PessoaJuridica
    {
        public int FkPessoaId { get; set; }
        [Column("CNPJ")]
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(30)]
        public string InscricaoEstadual { get; set; }
        [MaxLength(255)]
        public string ResponsavelTecnico { get; set; }

        public virtual Pessoa FkPessoa { get; set; }
    }
}

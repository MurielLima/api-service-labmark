using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Properties;

namespace Domain.Models
{
    public partial class PessoaJuridica : EntityBase
    {
        [Column("CNPJ")]
        [MaxLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [RegularExpression(@"(\d{2}[\.]?\d{3}[\.]?\d{3}[\/]?\d{4}[-]?\d{2})|(\d{3}[\.]?\d{3}[\.]?\d{3}[-]?\d{2})", ErrorMessage = "O documento deve estar no formato: XX.XXX.XXX/XXXX-XX")]
        public string Cnpj { get; set; }
        [MaxLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string InscricaoEstadual { get; set; }
        [MaxLength(255, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        public string ResponsavelTecnico { get; set; }
        [Key]
        [Column("fk_Pessoa_Id")]
        public int? FkPessoaId { get; set; }

        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaJuridica))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

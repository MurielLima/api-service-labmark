using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Properties;

namespace Domain.Models
{
    public partial class PessoaFisica : EntityBase
    {
        [Column("CPF")]
        [MaxLength(30, ErrorMessageResourceName = "MaxLength", ErrorMessageResourceType = typeof(Resources))]
        [RegularExpression(@"(\d{2}[\.]?\d{3}[\.]?\d{3}[\/]?\d{4}[-]?\d{2})|(\d{3}[\.]?\d{3}[\.]?\d{3}[-]?\d{2})", ErrorMessage = "O documento deve estar no formato: XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }
        [Key]
        [Column("fk_Pessoa_Id")]
        public int? FkPessoaId { get; set; }

        [ForeignKey(nameof(FkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaFisica))]
        public virtual Pessoa FkPessoa { get; set; }
    }
}

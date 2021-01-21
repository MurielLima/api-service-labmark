using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Labmark.Domain.Modules.Account.Infrastructure.EFCore.Views
{
    [Keyless]
    public partial class VIEW_PESSOA
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string NOME { get; set; }
        [StringLength(100)]
        public string EMAIL { get; set; }
        [Required]
        [StringLength(1)]
        public string TIPOPESSOA { get; set; }
        [StringLength(20)]
        public string CPFCNPJ { get; set; }
        [StringLength(255)]
        public string LOGRADOURO { get; set; }
        public int? NUMERO { get; set; }
        [StringLength(30)]
        public string BAIRRO { get; set; }
        [StringLength(10)]
        public string CEP { get; set; }
    }
}

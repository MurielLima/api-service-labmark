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
        [StringLength(1)]
        public string TIPOPESSOA { get; set; }
        [StringLength(14)]
        public string CPFCNPJ { get; set; }
        [StringLength(255)]
        public string LOGRADOURO { get; set; }
        [StringLength(5)]
        public string NUMERO { get; set; }
        [StringLength(30)]
        public string BAIRRO { get; set; }
        [StringLength(20)]
        public string COMPLEMENTO { get; set; }
        [StringLength(8)]
        public string CEP { get; set; }
        [StringLength(15)]
        public string TELEFONE { get; set; }
        [StringLength(3)]
        public string DDD { get; set; }
    }
}

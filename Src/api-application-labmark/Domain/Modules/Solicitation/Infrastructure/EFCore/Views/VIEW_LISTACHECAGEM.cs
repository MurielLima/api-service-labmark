using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;



namespace Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Views
{
    [Keyless]
    public partial class VIEW_LISTACHECAGEM
    {
        [Required]
        [StringLength(45)]
        public string PERGUNTA { get; set; }
        [Required]
        [StringLength(3)]
        public string RESPOSTA { get; set; }
        [Required]
        [StringLength(3)]
        public string JULGAMENTO { get; set; }
    }
}

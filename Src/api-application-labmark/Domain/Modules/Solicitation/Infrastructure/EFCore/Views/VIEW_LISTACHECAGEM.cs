using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
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

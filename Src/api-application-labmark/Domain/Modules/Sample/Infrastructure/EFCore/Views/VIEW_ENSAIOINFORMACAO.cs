using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Keyless]
    public partial class VIEW_ENSAIOINFORMACAO
    {
        [Required]
        [StringLength(100)]
        public string ENSAIO { get; set; }
        [Required]
        [StringLength(255)]
        public string METODOLOGIA { get; set; }
        public double? COLIFORMESESCHERICHIA { get; set; }
        public double? CONTAGEMMBLB { get; set; }
        [Required]
        [StringLength(255)]
        public string REFERENCIA { get; set; }
    }
}

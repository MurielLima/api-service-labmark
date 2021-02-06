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
        [StringLength(100)]
        public string ENSAIO { get; set; }
        [StringLength(255)]
        public string METODOLOGIA { get; set; }
        public double? COLIFORMESTERMOTOLERANTES { get; set; }
        public double? COLIFORMESTERMOTOTAIS { get; set; }
        public double? CONTAGEMMBLB { get; set; }
        [StringLength(255)]
        public string REFERENCIA { get; set; }
    }
}

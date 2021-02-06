using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Labmark.Models
{
    [Table("PessoaJuridica", Schema = "LAB")]
    public partial class PessoaJuridica
    {
        [Key]
        public int fkPessoaId { get; set; }
        [StringLength(14)]
        public string CNPJ { get; set; }
        [StringLength(30)]
        public string InscricaoEstadual { get; set; }
        [StringLength(255)]
        public string ResponsavelTecnico { get; set; }

        [ForeignKey(nameof(fkPessoaId))]
        [InverseProperty(nameof(Pessoa.PessoaJuridica))]
        public virtual Pessoa fkPessoa { get; set; }
    }
}

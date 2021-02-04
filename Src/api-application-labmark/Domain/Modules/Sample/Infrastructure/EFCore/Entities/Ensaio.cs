﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities
{
    [Table("Ensaio", Schema = "LAB")]
    public partial class Ensaio
    {
        public Ensaio()
        {
            fkEnsaiosPorAmostras = new HashSet<EnsaiosPorAmostra>();
        }

        [Key]
        public int Id { get; set; }
       
        public int Codigo { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
        [Required]
        [StringLength(255)]
        public string Metodologia { get; set; }
        [Required]
        [StringLength(255)]
        public string Referencia { get; set; }


        [InverseProperty(nameof(EnsaiosPorAmostra.fkEnsaio))]
        public virtual ICollection<EnsaiosPorAmostra> fkEnsaiosPorAmostras { get; set; }


      
        

    }
}

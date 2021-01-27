using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class DilutionDto
    {
        public int Id { get; set; }

        public int? ReadingId { get; set; }

        public double Dilution { get; set; }
        public string Lot { get; set; }

        public virtual Leitura Reading { get; set; }



    }
}

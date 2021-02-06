using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos
{
    public class DilutionDto
    { 
        public DilutionDto() { }
         public DilutionDto(EnumDilutions enumDilutions)
        {
            Code = enumDilutions;
            Reading= new ReadingDto();
        }

        public EnumDilutions Code { get; set; }

        public int Id { get; set; }

        public int? ReadingId { get; set; }

        public double Dilution { get; set; }
        public string Lot { get; set; }

        public virtual ReadingDto Reading { get; set; }



    }
}

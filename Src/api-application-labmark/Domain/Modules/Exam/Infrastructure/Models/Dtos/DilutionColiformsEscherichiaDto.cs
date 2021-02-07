using Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class DilutionColiformsEscherichiaDto
    {
        public DilutionColiformsEscherichiaDto(EnumReadings enumReadings)
        {
            Code = enumReadings;
           
        }

        public int Id { get; set; }
        public EnumReadings Code { get; set; }
        public int? fkColiformesEscherichiaId { get; set; }
        public int? Ordem { get; set; }
        public int? Diluicao { get; set; }
        public string Leitura { get; set; }
        public bool? Escolhida { get; set; }




    }
}

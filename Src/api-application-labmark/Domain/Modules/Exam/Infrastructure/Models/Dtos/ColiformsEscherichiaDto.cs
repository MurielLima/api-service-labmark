using System;
using System.Collections.Generic;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class ColiformsEscherichiaDto
    {
        public ColiformsEscherichiaDto()
        {
            dilutionColiformsEscherichiaDto = new List<DilutionColiformsEscherichiaDto>();
        }
        public int Id { get; set; }
      
        public int? Pointer_Reach { get; set; }
        public int? Point { get; set; }
        public double? Brilla { get; set; }
        public int BOD { get; set; }
        public double? WatherBath { get; set; }
        public int? FlowMicropipettor { get; set; }
        public double? Escherichia { get; set; }
        public double? ResultThermotolerantColiforms { get; set; }
        public double? ResultTotalColiforms { get; set; }
        public double? ReadingTotal { get; set; }
        public double? ReadingThermotolerant { get; set; }
        public string Observation { get; set; }
        public DateTime? DateFill { get; set; }
        public DateTime? DateResult { get; set; }
        public int AssayId { get; set; }
        public IList<DilutionColiformsEscherichiaDto> dilutionColiformsEscherichiaDto { get; set; }


    }
}

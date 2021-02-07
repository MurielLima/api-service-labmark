using System;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class ColiformsEscherichiaDto
    {
        public int Id { get; set; }
        public int? Point { get; set; }
        public double? Brilla { get; set; }
        public int BOD { get; set; }
        public double? WatherBath { get; set; }
        public int? FlowMicropipettor { get; set; }
        public double? Escherichia { get; set; }
        public double? TotalColifoms { get; set; }
        public double? TolerantColiforms { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        public double? Result { get; set; }
        public DateTime? DateResult { get; set; }
        

    }
}

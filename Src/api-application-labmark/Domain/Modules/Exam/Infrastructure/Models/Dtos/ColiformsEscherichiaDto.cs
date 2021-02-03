using System;
using Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class ColiformsEscherichiaDto
    {
        public int Point { get; set; }
        public string Brilla { get; set; }
        public int BOD { get; set; }
        public int WatherBath { get; set; }
        public int FlowMicropipettor { get; set; }
        public string Escherichia { get; set; }
        public string TotalColifoms { get; set; }
        public string TolerantColiforms { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public string Result { get; set; }
        public DateTime DateTime { get; set; }
        public SampleTestDto EssayBySample { get; set; }

    }
}

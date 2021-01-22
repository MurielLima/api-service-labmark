using System;
using Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class CountMBLBDto
    {
        public int Point { get; set; }
        public string Reading { get; set; }
        public string Dilution { get; set; }
        public string Result { get; set; }
        public DateTime DateOfResult { get; set; }
        public SampleTestDto EssayBySample { get; set; }
    }
}

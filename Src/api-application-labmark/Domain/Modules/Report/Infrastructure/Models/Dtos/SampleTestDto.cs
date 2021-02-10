using System.Collections.Generic;

namespace Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos
{
    public class SampleTestDto
    {
        public SampleTestDto()
        {
            Exam = new List<ExamDto>();
        }
        public int Id { get; set; }
        public int Sample { get; set; }
        public int Assay { get; set; }
        public IList<ExamDto> Exam { get; set; }


    }
}

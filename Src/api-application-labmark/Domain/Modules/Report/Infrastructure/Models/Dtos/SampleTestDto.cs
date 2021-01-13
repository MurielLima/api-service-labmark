using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class SampleTestDto
    {
        public int Id { get; set; }
        public int Sample { get; set; }
        public int Assay { get; set; }
        public IList<ExamDto> Exam { get; set; }


    }
}

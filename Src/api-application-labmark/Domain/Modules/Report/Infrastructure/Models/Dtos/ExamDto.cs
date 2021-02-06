using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class ExamDto
    {
        public ExamDto()
        {
            ColifomsEscherichia = new ColiformsEscherichiaDto();
            CountMBLB = new CountMBLBDto();
        }
        public ColiformsEscherichiaDto ColifomsEscherichia { get; set; }
        public CountMBLBDto CountMBLB { get; set; }

    }
}

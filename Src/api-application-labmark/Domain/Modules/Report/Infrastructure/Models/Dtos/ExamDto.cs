using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class ExamDto
    {
        public ColifomsEscherichiaDto ColifomsEscherichia { get; set; }
        public CountMBLBDto CountMBLB { get; set; }

    }
}

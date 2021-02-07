using System;
using Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class CountMBLBDto
    {
        public int Id { get; set; }
        public float Reading { get; set; }
        public int? Dilution { get; set; }
        public float Result { get; set; }
        public DateTime? DateOfResult { get; set; }
        public int AssayId { get; set; }


    }
}

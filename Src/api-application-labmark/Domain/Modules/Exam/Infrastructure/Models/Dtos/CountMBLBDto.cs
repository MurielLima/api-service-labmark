using System;
using Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos
{
    public class CountMBLBDto
    {
        public int Id { get; set; }
        public string Reading { get; set; }
        public string Dilution { get; set; }
        public double? Result { get; set; }
        public DateTime? DateOfResult { get; set; }
        public int AssayId { get; set; }


    }
}

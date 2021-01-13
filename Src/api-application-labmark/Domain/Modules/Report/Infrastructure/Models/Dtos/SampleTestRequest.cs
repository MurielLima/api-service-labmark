using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class SampleTestRequest
    {
        public int Id { get; set; }
        public int Sample { get; set; }
        public int Assay { get; set; }
    }
}

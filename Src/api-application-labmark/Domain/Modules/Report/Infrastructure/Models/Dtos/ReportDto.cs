using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class ReportDto
    {
        public ClientDto Client { get; set; }

        public IList<SampleTestDto> Result { get; set; }
      
    }
}

using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Report.Infrastructure.Models.Dtos
{
    public class ReportDto
    {
        public ClientDto Client { get; set; }

        public IList<SampleTestDto> Result { get; set; }

    }
}

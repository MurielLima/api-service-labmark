using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos
{
    public class ReportDto
    {
            public string Format { get; set; }
            public bool Inline { get; set; }
            public string Parameter { get; set; }

    }
}

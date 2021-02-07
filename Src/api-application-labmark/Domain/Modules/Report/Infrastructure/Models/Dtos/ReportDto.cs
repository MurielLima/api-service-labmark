using System.Collections.Generic;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.ReportSample.Infrastructure.Models.Dtos
{
    public class ReportDto
    {
            public int[] Ensaios { get; set; }
            public int AmostraId { get; set; }

    }
}

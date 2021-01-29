using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Models.Enums
{
    public enum EnumReadings
    {
        [Description("Primeira Leitura")]
        FirstReading = 1,
        [Description("Segunda Leitura")]
        SecondReading = 2
    }
}

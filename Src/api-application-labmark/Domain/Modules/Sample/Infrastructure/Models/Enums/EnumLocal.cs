using System.ComponentModel;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums
{
    public enum EnumLocal
    {
        [Description("Cozinha")]
        Cozinha = 01,
        [Description("Lavanderia")]
        Lavanderia = 02,
        [Description("Casa")]
        Casa = 05
    }
}

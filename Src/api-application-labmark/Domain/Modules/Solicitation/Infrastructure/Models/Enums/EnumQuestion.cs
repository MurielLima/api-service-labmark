using System.ComponentModel;

namespace Labmark.Domain.Modules.Solicitation.Infrastructure.Models.Enums
{
    public enum EnumQuestion
    {
        [Description("A amostra foi embalada corretamente ?")]
        Packaged = 1,
        [Description("A amostra foi transportada corretamente ?")]
        Transport = 2,
        [Description("A temperatura da amostra está adequada ?")]
        Temperature = 3,
        [Description("O volume da amostra é suficiente ? ")]
        Volume = 4,
        [Description("O processo está correto ?")]
        Proccess = 5,

    }
}

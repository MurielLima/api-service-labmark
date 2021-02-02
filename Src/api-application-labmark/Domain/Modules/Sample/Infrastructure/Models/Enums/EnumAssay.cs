using System.ComponentModel;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums
{
    public enum EnumAssay
    {
        [Description("Contagem de Bacillus cereus")]
        M01 = 01,
        [Description("Contagem total de Bolores e Leveduras")]
        M02 = 02,
        [Description("Contagem de Clostridium sulfito redutor")]
        M05 = 05,
        [Description("Contagem total de Coliformes Termotolerantes")]
        M06 = 06,
        [Description("Contagem de Coliformes Totais")]
        M07 = 07,
        [Description("Contagem de Staphylococcus aureus")]
        M12 = 12,
        [Description("Contagem de Staphylococcus Coagulase Positiva")]
        M12A = 120,
        [Description("Contagem de Mesófilos Aeróbios estritos e Facultativos Viáveis")]
        M13 = 13,
        [Description("Contagem Total de Enterobactérias")]
        M14 = 14,
        [Description("NMP de Coliformes Termotolerantes")]
        M15 = 15,
        [Description("NMP de Coliformes  Termotolerantes")]
        M15L = 150,
        [Description("NMP de Coliformes Totais")]
        M16 = 16,
        [Description("NMP de Coliformes  Totais")]
        M16L = 160,
        [Description("Pesquisa de Listeria monocytogenes ")]
        M20 = 20,
        [Description("Pesquisa de Salmonella sp")]
        M26 = 26,
        [Description("Contagem Total de Escherichia coliformes")]
        M32 = 32,
        [Description("Acidez")]
        AC = 101,
        [Description("Contagem de Bactérias Láticas")]
        BL = 102,
        [Description("Crioscopia")]
        CR = 103,
        [Description("Quantificação de Cloro")]
        CLORO = 104,
        [Description("Fosfatase")]
        FOS = 105




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Models.Enums
{
    public enum EnumAssay
    {
       [Description("M01 Contagem de Bacillus cereus")]
        M01 = 01,
        [Description("M02 Contagem total de Bolores e Leveduras")]
        M02 = 02,
        [Description("M05 Contagem de Clostridium sulfito redutor")]
        M05 = 05,
        [Description("M06 Contagem total de Coliformes Termotolerantes")]
        M06 = 06,
        [Description("M07 Contagem de Coliformes Totais")]
        M07 = 07,
        [Description("M12 Contagem de Staphylococcus aureus")]
        M12 = 12,
        [Description("M12A Contagem de Staphylococcus Coagulase Positiva")]
        M12A = 120,
        [Description("M13 Contagem de Mesófilos Aeróbios estritos e Facultativos Viáveis")]
        M13 = 13,
        [Description("M14 Contagem Total de Enterobactérias")]
        M14 = 14,
        [Description("M15 NMP de Coliformes Termotolerantes")]
        M15 = 15,
        [Description("M15L NMP de Coliformes  Termotolerantes")]
        M15L = 150,
        [Description("M16 NMP de Coliformes Totais")]
        M16 = 16,
        [Description("M16L NMP de Coliformes  Totais")]
        M16L = 160,
        [Description("M20 Pesquisa de Listeria monocytogenes ")]
        M20 = 20,
        [Description("M26 Pesquisa de Salmonella sp")]
        M26 = 26,
        [Description("M32 Contagem Total de Escherichia coli")]
        M32 = 32,
        [Description("AC Acidez")]
        AC = 101,
        [Description("BL Contagem de Bactérias Láticas")]
        BL = 102,
        [Description("CR Crioscopia")]
        CR = 103,
        [Description("QuantIficação de Cloro")]
        CLORO = 104,
        [Description("FOS Fosfatase")]
        FOS = 105




    }
}

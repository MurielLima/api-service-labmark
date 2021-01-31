using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ColiformesEscherichiaMapToColiformsEscherichiaDto
    {

        public static ColiformsEscherichiaDto Map(ColiformesEscherichia coliformesEscherichia, ColiformsEscherichiaDto coliformsEscherichiaDto)
        {
            coliformsEscherichiaDto.BOD = coliformesEscherichia.BOD ?? 0;
            coliformsEscherichiaDto.Brilla = coliformesEscherichia.Brilla;
            coliformsEscherichiaDto.DateOfCompletion = coliformesEscherichia.DataResultado;
            coliformsEscherichiaDto.DateResult = coliformesEscherichia.DataResultado;
            coliformsEscherichiaDto.Escherichia = coliformesEscherichia.Escherichia;
            coliformsEscherichiaDto.FlowMicropipettor = coliformesEscherichia.Fluxo_Micropipetador;
            coliformsEscherichiaDto.Result = coliformesEscherichia.Resultado;
            coliformsEscherichiaDto.TotalColifoms = coliformesEscherichia.ColiformesTotais;
            coliformsEscherichiaDto.TolerantColiforms = coliformesEscherichia.ColiformesTermotolerantes;
            coliformsEscherichiaDto.WatherBath = coliformesEscherichia.BanhoMaria;
            coliformsEscherichiaDto.Point = coliformesEscherichia.Ponteira_Alcada;
            


            return coliformsEscherichiaDto;
        }








    }
}

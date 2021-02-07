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

        public static ColiformsEscherichiaDto Map(ColiformsEscherichiaDto coliformsEscherichiaDto, ColiformesEscherichia coliformesEscherichia)
        {
            coliformsEscherichiaDto.Id = coliformesEscherichia.Id;
            coliformsEscherichiaDto.BOD = coliformesEscherichia.BOD ?? 0;
            coliformsEscherichiaDto.Brilla = coliformesEscherichia.Brilla;
            coliformsEscherichiaDto.DateResult = coliformesEscherichia.DataResultado;
            coliformsEscherichiaDto.Escherichia = coliformesEscherichia.Escherichia;
            coliformsEscherichiaDto.FlowMicropipettor = coliformesEscherichia.Fluxo_Micropipetador;
            coliformsEscherichiaDto.ResultThermotolerantColiforms = coliformesEscherichia.ResultadoColiformesTermotolerantes;
            coliformsEscherichiaDto.ResultTotalColiforms = coliformesEscherichia.ResultadoColiformesTotais;
            coliformsEscherichiaDto.WatherBath = coliformesEscherichia.BanhoMaria;
            coliformsEscherichiaDto.Pointer_Reach = coliformesEscherichia.Ponteira_Alcada;
            coliformsEscherichiaDto.DateFill = coliformesEscherichia.DataPreenchimento;
            
            coliformsEscherichiaDto.Observation = coliformesEscherichia.Observacao;
            coliformsEscherichiaDto.ReadingThermotolerant = coliformesEscherichia.LeituraTermotolerantes;
            coliformsEscherichiaDto.ReadingTotal = coliformesEscherichia.LeituraTotais;

            return coliformsEscherichiaDto;
        }








    }
}

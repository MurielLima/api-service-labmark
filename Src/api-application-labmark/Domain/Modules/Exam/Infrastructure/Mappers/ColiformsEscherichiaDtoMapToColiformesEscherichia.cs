using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Mappers
{
    public class ColiformsEscherichiaDtoMapToColiformesEscherichia
    {
        public static ColiformesEscherichia Map(ColiformesEscherichia coliformesEscherichia, ColiformsEscherichiaDto coliformsEscherichiaDto)
        {
            coliformesEscherichia.Id = coliformsEscherichiaDto.Id;
            coliformesEscherichia.BOD = coliformsEscherichiaDto.BOD;
            coliformesEscherichia.Brilla = coliformsEscherichiaDto.Brilla;
            coliformesEscherichia.DataResultado = coliformsEscherichiaDto.DateOfCompletion;
            coliformesEscherichia.DataResultado = coliformsEscherichiaDto.DateResult;
            coliformesEscherichia.Escherichia = coliformsEscherichiaDto.Escherichia;
            coliformesEscherichia.Fluxo_Micropipetador = coliformsEscherichiaDto.FlowMicropipettor;
            coliformesEscherichia.Resultado = coliformsEscherichiaDto.Result;
            coliformesEscherichia.ColiformesTotais = coliformsEscherichiaDto.TotalColifoms;
            coliformesEscherichia.ColiformesTermotolerantes = coliformsEscherichiaDto.TolerantColiforms;
            coliformesEscherichia.BanhoMaria = coliformsEscherichiaDto.WatherBath;
            coliformesEscherichia.Ponteira_Alcada = coliformsEscherichiaDto.Point;
            


            return coliformesEscherichia;
        }










    }
}

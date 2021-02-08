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
            coliformesEscherichia.DataResultado = coliformsEscherichiaDto.DateResult;
            coliformesEscherichia.Escherichia = coliformsEscherichiaDto.Escherichia;
            coliformesEscherichia.Fluxo_Micropipetador = coliformsEscherichiaDto.FlowMicropipettor;
            coliformesEscherichia.ResultadoColiformesTotais = coliformsEscherichiaDto.ResultTotalColiforms;
            coliformesEscherichia.ResultadoColiformesTermotolerantes = coliformsEscherichiaDto.ResultThermotolerantColiforms;
            coliformesEscherichia.BanhoMaria = coliformsEscherichiaDto.WatherBath;
            coliformesEscherichia.Ponteira_Alcada = coliformsEscherichiaDto.Pointer_Reach;
            coliformesEscherichia.DataPreenchimento = coliformsEscherichiaDto.DateFill;
           
            coliformesEscherichia.LeituraTermotolerantes = coliformsEscherichiaDto.ReadingThermotolerant;
            coliformesEscherichia.LeituraTotais = coliformsEscherichiaDto.ReadingTotal;
            coliformesEscherichia.Pipeta = coliformsEscherichiaDto.Point;
            foreach(var a in coliformsEscherichiaDto.dilutionColiformsEscherichiaDto)
            {
                var dilution = new DiluicaoColiformesEscherichia();
                dilution.Diluicao = a.Diluicao;
                dilution.Escolhida = a.Escolhida;
                dilution.Leitura = a.Leitura;
                dilution.Ordem = a.Ordem;
                coliformesEscherichia.DiluicaoColiformesEscherichium.Add(dilution);
            }
            
           
            return coliformesEscherichia;
        }










    }
}
